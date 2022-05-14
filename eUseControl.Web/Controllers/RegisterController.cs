using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;
        public RegisterController()
        {
            var bl = new BussinesLogic();
            _session = bl.getSessionBL();
        }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                URegisterData data = new URegisterData
                {
                    Username = register.Username,
                    Email = register.Email,
                    Password = register.Password
                };
                var userRegister = _session.UserRegister(data);
                if (userRegister.Status)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}