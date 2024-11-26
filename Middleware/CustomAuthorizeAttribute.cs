using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using GraphQL.AspNet.Execution.Contexts;
using GraphQL.AspNet.Interfaces.Controllers;
using GraphQL.AspNet.Interfaces.Execution;
using GraphQL.AspNet.Interfaces.Middleware;
using GraphQL.AspNet.Middleware;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GraphQL.AspNet.Execution;
using GraphQL.AspNet.Middleware;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace GraphQLAuthorization.Middleware
{
    public class CustomAuthorizeAttribute : IGraphQLMiddleware, IGraphFieldAuthorizationAttribute
    {
        private readonly string _role;

        public CustomAuthorizeAttribute(string role)
        {
            _role = role;
        }

        /*public override async Task<IGraphActionResult> AuthorizeAsync(IGraphFieldAuthorizationContext context)
        {
            var httpContext = context?.Request?.HttpContext as HttpContext;
            if (httpContext == null)
            {
                return context.Result(AuthorizationStatus.Deny);
            }

            var user = httpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                return context.Result(AuthorizationStatus.Deny);
            }

            var userRoles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            if (!userRoles.Contains(_role))
            {
                return context.Result(AuthorizationStatus.Deny);
            }

            return context.Result(AuthorizationStatus.Grant);
        }
        */

        public Task InvokeAsync(SchemaItemSecurityChallengeContext context, GraphMiddlewareInvocationDelegate<SchemaItemSecurityChallengeContext> next, CancellationToken cancelToken)
        {
            Console.WriteLine("ISchemaItemSecurityMiddleware ");

            throw new NotImplementedException();
        }
    }
}