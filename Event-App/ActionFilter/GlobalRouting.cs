using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Event_App.ActionFilter
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        public GlobalRouting(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            if (controller.Equals("Home"))
            {
                if (_claimsPrincipal.IsInRole("Person"))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "Person", null);
                }
                else if (_claimsPrincipal.IsInRole("Group"))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "Group", null);
                }
                else if (_claimsPrincipal.IsInRole("Venue"))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "Venue", null);
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

    }
}
