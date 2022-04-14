using Dal_GestContact.Entities;
using Dal_GestContact.Interface;
using Microsoft.AspNetCore.Mvc;
using WEB_GestContact.Models;
using WEB_GestContact.Tools;

namespace WEB_GestContact.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepo _repo;
        private readonly SessionManager _sessionManager;

        public ContactController(IContactRepo repo, SessionManager sessionManager)
        {
            _repo = repo;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        [AuthRequired]
        public IActionResult Details(int id)
        {
            return View(_repo.GetById(id, _sessionManager.CurrentUser.Token));
        }
        [AuthRequired]
        public IActionResult Create()
        {
            return View();
        }
        [AuthRequired]
        [HttpPost]
        public IActionResult Create(ContactForm form)
        {
            if (!ModelState.IsValid) return View(form);

            _repo.Post(form.CreateToDal(), _sessionManager.CurrentUser.Token);

            return RedirectToAction("Index");
        }

        [AdminRequired]
        public IActionResult Edit(int id)
        {
            
            return View(_repo.GetById(id, _sessionManager.CurrentUser.Token).ToUpdate());
        }
        [AdminRequired]
        [HttpPost]
        public IActionResult Edit(ContactUpdateForm form)
        {
            if (!ModelState.IsValid) return View(form);

            _repo.Update(form.UpdateToDal(), _sessionManager.CurrentUser.Token);

            return RedirectToAction("Index");
        }
        [AdminRequired]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id, _sessionManager.CurrentUser.Token);

            return RedirectToAction("Index");
        }
    }
}
