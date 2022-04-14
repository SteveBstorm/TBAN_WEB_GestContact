using Dal_GestContact.Interface;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using WEB_GestContact.Models;
using WEB_GestContact.Tools;

namespace WEB_GestContact.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepo _repo;
        private readonly SessionManager _sessionManager;

        public UserController(IUserRepo repo, SessionManager sessionManager)
        {
            _repo = repo;
            _sessionManager = sessionManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid) return View(form);

            try
            {
                string token = JsonSerializer.Deserialize<string>(_repo.Login(form.Email, form.Password));
                string tokendes = _repo.Login(form.Email, form.Password);


                JwtSecurityToken jwt = new JwtSecurityToken(token);


                AppUser currentUser = _repo.GetById(int.Parse(jwt.Claims.First(x => x.Type == ClaimTypes.Sid).Value), token).ToASP();

                currentUser.Role = jwt.Claims.First(x => x.Type == ClaimTypes.Role).Value;
                currentUser.Token = token;

                _sessionManager.CurrentUser = currentUser;
                return Content(_sessionManager.CurrentUser.Role);
                //return RedirectToAction("Index", "Contact");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }

        }
    }
}
