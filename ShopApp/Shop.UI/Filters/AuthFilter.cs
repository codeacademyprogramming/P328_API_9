using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Security.Policy;

namespace Shop.UI.Filters
{
    public class AuthFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Cookies["auth_token"] == null)
            {
                if (context.HttpContext.Request.Path.Value!="/")
                {
                    var uri = new Uri(context.HttpContext.Request.GetEncodedUrl());
                    var query = Uri.EscapeDataString(uri.PathAndQuery);
                    context.Result = new RedirectResult($"/account/login?returnUrl={query}");
                }
                else 
                    context.Result = new RedirectResult($"/account/login");
                return;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
