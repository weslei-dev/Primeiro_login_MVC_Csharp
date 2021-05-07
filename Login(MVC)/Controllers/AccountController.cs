using Login_MVC_.Models;
using Login_MVC_.Repositorios;
using System;
using System.Web.Mvc;

namespace Login_MVC_.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountRepository _accountRepository;
        private bool isLogged { get { return Session != null && (Session["logged"] != null && (bool)Session["logged"] == true); } }

        public AccountController()
        {
            _accountRepository = new AccountRepository();
        }

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            if (isLogged)
                return RedirectToAction("Create");

            return View("Login");
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View("Error");
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!isLogged)
                return RedirectToAction("Error");

            return View("Create");
        }

        public ActionResult Verify(Account acc)
        {
            var result = _accountRepository.Verify(acc);
            if (result == null)
                return RedirectToAction("Error");

            Session["logged"] = true;

            return RedirectToAction("Create");
        }
    }
}