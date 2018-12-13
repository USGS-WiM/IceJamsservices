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
using IceJamsAgent.Resources;
using System.Threading.Tasks;
using System.Collections.Generic;
using WiM.Resources;
using IceJamsDB.Resources;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace IceJamsServices.Controllers
{
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        public EventsController(IIceJamsAgent agent ) : base(agent)
        {
        }
        #region METHODS
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(agent.GetEvents().ToList());
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id < 0) return new BadRequestResult(); // This returns HTTP 404
                return Ok(await agent.GetEvent(id));
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Authorize(Policy = "Restricted")]
        public async Task<IActionResult> Post([FromBody]Event entity)
        {
            try
            {
                entity.ObserverID = this.LoggedInUser().ID;

                if (!isValid(entity)) return new BadRequestResult(); // This returns HTTP 404
                return Ok(await agent.Add(entity));
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Put(int id, [FromBody]Event entity)
        {
            try
            {
                return Ok(await agent.Update(id,entity));
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
                await agent.DeleteEvent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return await HandleExceptionAsync(ex);
            }
        }
        #endregion

    }
}
