using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ImageUploader.security
{
    public class SecurityStrategyAuthenticationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var key_value = context.RouteData.Values["key"];
            //验证key是否是有效的
            if (!SecurityStrategy.getInstance().getCurrentKey().Equals(key_value))
            {
                //无效
                context.HttpContext.Response.Redirect("/error", true);
            }
        }
    }
}
