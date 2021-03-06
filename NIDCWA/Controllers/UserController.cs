﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using NIDCWA.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace NIDCWA.Controllers
{
    public class UserController : FoundationController
    {
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
        [ValidateAntiForgeryToken]
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
                    //user.Password = Helpers.PasswordHash.CreateHash(model.password);
                    user.Active = 1;
                    entities.User.Add(user);
                    entities.SaveChanges();
                }
                else
                {
                    User user = (from u in entities.User
                                 where u.ID == model.ID
                                 select u).Single();
                    user.Username = model.username;
                    entities.SaveChanges();
                }
                return RedirectToAction("index", "Users");
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult Activate()
        {
            int error = 1;

            if (Request.IsAjaxRequest())
            {
                int ID;
                int.TryParse(Request["id"].ToString(), out ID);

                byte active;
                byte.TryParse(Request["active"].ToString(), out active);
                if (active == 1)
                {
                    active = 0;
                }
                else
                {
                    active = 1;
                }

                User user = (from u in entities.User
                             where u.ID == ID
                             select u).Single();
                user.Active = active;
                entities.SaveChanges();

                error = 0;
            }

            return Json(new { error = error });
        }
    }
}