using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WEB_GestContact.Tools
{
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter)) { }
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {
        private readonly SessionManager _sessionManager;
        public AuthRequiredFilter(SessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(_sessionManager.CurrentUser is null)
            {
                context.Result = new RedirectToRouteResult(new { action = "Login", controller = "User" });
            }
        }
    }
}
