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

        public ContactController(IContactRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_repo.GetById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactForm form)
        {
            if (!ModelState.IsValid) return View(form);

            _repo.Post(form.CreateToDal());

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            
            return View(_repo.GetById(id).ToUpdate());
        }

        [HttpPost]
        public IActionResult Edit(ContactUpdateForm form)
        {
            if (!ModelState.IsValid) return View(form);

            _repo.Update(form.UpdateToDal());

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
