//------------------------------------------------------------------------------
//----- HttpController ---------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WiM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   Handles resources through the HTTP uniform interface.
//
//discussion:   Controllers are objects which handle all interaction with resources. 
//              
//
// 

using Microsoft.AspNetCore.Mvc;
using System;
using IceJamsAgent;
using System.Threading.Tasks;
using System.Collections.Generic;
using WiM.Resources;
using WiM.Security;
using IceJamsDB.Resources;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Text;

namespace IceJamsServices.Controllers
{
    [Route("[controller]")]
    public class ObserversController : ControllerBase
    {
        public ObserversController(IIceJamsAgent agent ) : base(agent)
        {
        }
        #region METHODS
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(agent.GetObservers());
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }
        [HttpGet("/Login")]
        [Authorize(Policy = "Restricted")]
        public async Task<IActionResult> GetLoggedInUser()
        {
            try
            {
                return Ok(LoggedInUser());
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }

        }
        [HttpGet("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id < 0) return new BadRequestResult(); // This returns HTTP 404
                return Ok(await agent.GetObserver(id));
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Post([FromBody]Observer entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.FirstName) || string.IsNullOrEmpty(entity.LastName) ||
                    string.IsNullOrEmpty(entity.Username) || string.IsNullOrEmpty(entity.Email) ||
                    entity.RoleID < 1) return new BadRequestObjectResult(new Error(errorEnum.e_badRequest, "You are missing one or more required parameter.")); // This returns HTTP 404

                if (string.IsNullOrEmpty(entity.Password))
                    entity.Password = generateDefaultPassword(entity);
                else
                    entity.Password = Encoding.UTF8.GetString(Convert.FromBase64String(entity.Password));

                entity.Salt = Cryptography.CreateSalt();
                entity.Password = Cryptography.GenerateSHA256Hash(entity.Password, entity.Salt);

                if (!isValid(entity)) return new BadRequestResult(); // This returns HTTP 404
                var x = await agent.Add(entity);
                //remove info not relevant
                x.Salt = string.Empty;
                x.Password = string.Empty;

                return Ok(x);
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Restricted")]
        public async Task<IActionResult> Put(int id, [FromBody]Observer entity)
        {
            Observer ObjectToBeUpdated = null;
            try
            {
                if (string.IsNullOrEmpty(entity.FirstName) || string.IsNullOrEmpty(entity.LastName) ||
                    string.IsNullOrEmpty(entity.Username) || string.IsNullOrEmpty(entity.Email) ||
                    entity.RoleID < 1) return new BadRequestObjectResult(new Error(errorEnum.e_badRequest)); // This returns HTTP 404

                //fetch object, assuming it exists
                ObjectToBeUpdated = await agent.FindObserver(id);
                if (ObjectToBeUpdated == null) return new NotFoundObjectResult(entity);

                if (!User.IsInRole("Administrator") || LoggedInUser().ID != id)
                    return new UnauthorizedResult();// return HTTP 401

                ObjectToBeUpdated.FirstName = entity.FirstName;
                ObjectToBeUpdated.LastName = entity.LastName;
                ObjectToBeUpdated.OtherInfo = entity.OtherInfo;
                ObjectToBeUpdated.PrimaryPhone = entity.PrimaryPhone;
                ObjectToBeUpdated.SecondaryPhone = entity.SecondaryPhone;
                ObjectToBeUpdated.Email = entity.Email;

                //admin can only change role
                if (User.IsInRole("Administrator"))
                    ObjectToBeUpdated.RoleID = entity.RoleID;

                //change password if needed
                if (!string.IsNullOrEmpty(entity.Password) && !Cryptography
                            .VerifyPassword(Encoding.UTF8.GetString(Convert.FromBase64String(entity.Password)),
                                                                    ObjectToBeUpdated.Salt, ObjectToBeUpdated.Password))
                {
                    ObjectToBeUpdated.Salt = Cryptography.CreateSalt();
                    ObjectToBeUpdated.Password = Cryptography.GenerateSHA256Hash(Encoding.UTF8
                                .GetString(Convert.FromBase64String(entity.Password)), ObjectToBeUpdated.Salt);

                }//end if

                var x = await agent.Update(id, entity);
                //remove info not relevant
                x.Salt = string.Empty;
                x.Password = string.Empty;

                return Ok(x);
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await agent.DeleteObserver(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }
        #endregion
        #region HELPER METHODS
        private string generateDefaultPassword(Observer entity)
        {
            //N55Defau1t+numbercharInlastname+first2letterFirstName
            string generatedPassword = "Ic3Defau1t" + entity.LastName.Length + entity.FirstName.Substring(0, 2);

            return generatedPassword;
        }
        #endregion
    }
}
