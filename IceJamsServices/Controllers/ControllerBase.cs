using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using IceJamsAgent;
using IceJamsDB.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WiM.Resources;

namespace IceJamsServices.Controllers
{
    public abstract class ControllerBase:WiM.Services.Controllers.ControllerBase
    {
        protected IIceJamsAgent agent;

        public ControllerBase(IIceJamsAgent sa)
        {
            this.agent = sa;
        }

        public Observer LoggedInUser()
        {
            return new Observer()
            {
                ID = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault()),
                FirstName = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault(),
                LastName = User.Claims.Where(c => c.Type == ClaimTypes.Surname)
                   .Select(c => c.Value).SingleOrDefault(),
                Username = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => c.Value).SingleOrDefault(),
                RoleID = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.Anonymous)
                   .Select(c => c.Value).SingleOrDefault())
            };
        }
        protected new IActionResult HandleException(Exception ex)
        {
            if (ex is DbUpdateException)
            {
                string errorText;
                if (ex.InnerException is Npgsql.PostgresException && dbBadRequestErrors.TryGetValue(Convert.ToInt32(ex.InnerException.Data["Code"]), out errorText))
                {
                    return new BadRequestObjectResult(new Error(errorEnum.e_badRequest, errorText));
                }
                else
                {
                    return StatusCode(500, new Error(errorEnum.e_internalError, "A managed database error occured."));
                }
            }

            else
            {
                return StatusCode(500, new Error(errorEnum.e_internalError, "An error occured while processing your request."));
            }
        }
        private Dictionary<int, string> dbBadRequestErrors = new Dictionary<int, string>
        {
            //https://www.postgresql.org/docs/9.4/static/errcodes-appendix.html
            {23502, "One of the properties requires a value."},
            {23505, "One of the properties is marked as Unique index and there is already an entry with that value."},
            {23503, "One of the related features prevents you from performing this operation to the database." }
        };

        protected void sm(List<Message> messages)
        {
            if (messages.Count < 1) return;
            HttpContext.Items[WiM.Services.Middleware.X_MessagesExtensions.msgKey] = messages;
        }
    }
}
