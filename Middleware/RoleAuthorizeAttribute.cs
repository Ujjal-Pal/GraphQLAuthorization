using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace GraphQLAuthorization.Middleware
{
    public class RoleAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _roles;

        public RoleAuthorizeAttribute(string roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("RoleAuthorizeAttribute.OnAuthorization : " + _roles);

            var userRoles = context.HttpContext.User.Claims
            .Where(c => c.Type == ClaimTypes.Role)//"role")
            .Select(c => c.Value);

            if (!userRoles.Contains(_roles))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
