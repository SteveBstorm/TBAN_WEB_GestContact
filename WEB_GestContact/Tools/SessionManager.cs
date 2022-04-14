using System.Text.Json;
using WEB_GestContact.Models;

namespace WEB_GestContact.Tools
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        public AppUser? CurrentUser
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_session.GetString("user")))
                {
                    return null;
                }
                return JsonSerializer.Deserialize<AppUser>(_session.GetString("user"));
            }
            set { _session.SetString("user", JsonSerializer.Serialize(value)); }
        }
    }
}
