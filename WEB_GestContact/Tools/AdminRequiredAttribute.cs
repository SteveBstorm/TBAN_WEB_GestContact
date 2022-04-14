using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WEB_GestContact.Tools
{
    public class AdminRequiredAttribute : TypeFilterAttribute
    {
        public AdminRequiredAttribute() : base(typeof(AdminRequiredFilter)) { }
    }

    public class AdminRequiredFilter : IAuthorizationFilter
    {
        private readonly SessionManager _sessionManager;
        public AdminRequiredFilter(SessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_sessionManager.CurrentUser is null || _sessionManager.CurrentUser.Role != "admin")
            {
                context.Result = new RedirectToRouteResult(new { action = "Login", controller = "User" });
            }
        }
    }
}
