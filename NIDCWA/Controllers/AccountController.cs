using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using NIDCWA.Models;

namespace NIDCWA.Controllers
{
    public class AccountController : FoundationController
    {
        // GET: /User/
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: /User/
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = Helpers.SHA256.Encode(model.password);

                if (model.IsValid(model.username, hashedPassword))
                {

                    User user = (from u in entities.User
                                 where u.Username == model.username &&
                                 u.Password == hashedPassword && u.Active == 1
                                 select u).Single();

                    FormsAuthentication.SetAuthCookie(user.ID.ToString(), false);

                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "User");
        }
    }
}