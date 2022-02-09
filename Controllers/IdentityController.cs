using Currency_Exchange2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class IdentityController : Controller
    {
        // GET: Identity
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new PersonLoginRequest());
        }
        [HttpPost]
        public ActionResult Login(PersonLoginRequest model)
        {
            if (ModelState.IsValid)
            {
                var person = Person.Login(model);
                if (person != null)
                {
                    Session["email"] = person.Email;
                    Session["fullName"] = person.Name + " " + person.LastName;
                    Session["role"] = person.Role;
                    if (person.Role == RoleType.Admin)
                    {
                        return RedirectToAction("Index", "Currency");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Te dhena te pasakta";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Te dhena te pasakta";
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View(new PersonAddRequest());
        }
        [HttpPost]
        public ActionResult Register(PersonAddRequest model)
        {
            if (ModelState.IsValid)
            {
                var person = Person.GetByEmail(model.Email);
                if (person != null)
                {
                    ViewBag.ErrorMessage = "Email exists";
                    return View(model);
                }
                else
                {
                    if (Person.Register(model))
                    {
                        return RedirectToAction("Login", "Identity", new { message = "U shtua me sukses, vendos te dhenat per login" });
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Register could not be completed";
                        return View(model);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}