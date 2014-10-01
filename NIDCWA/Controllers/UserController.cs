﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using NIDCWA.Models;

namespace NIDCWA.Controllers
{
    public class UserController : FoundationController
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

                    return RedirectToAction("", "");
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

        [HttpGet]
        public ActionResult Save()
        {
            int ID = 0;
            UserSaveViewModel model;

            if (RouteData.Values["id"] != null)
            {
                ID = Convert.ToInt16(RouteData.Values["id"].ToString());
            }

            if (ID == 0)
            {
                model = new UserSaveViewModel();
            }
            else
            {
                model = (from u in entities.User
                         where u.ID == ID
                         select new UserSaveViewModel
                         {
                             ID = u.ID,
                             username = u.Username,
                             password = u.Password
                         }).Single();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(UserSaveViewModel model)
        {
            if (ModelState.IsValid)
            {
                DbContext context = new DbContext("NECCaptran_DevEntities");

                if (model.ID == 0)
                {
                    User user = new User();
                    user.Username = model.username;
                    user.Password = Helpers.SHA256.Encode(model.password);
                    user.Active = 1;
                    entities.User.Add(user);
                    entities.SaveChanges();
                }
                return RedirectToAction("Login", "User");
            }
            return View(model);
        }
    }
}