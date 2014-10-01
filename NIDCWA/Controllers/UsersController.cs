using NIDCWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NIDCWA.Controllers
{
    public class UsersController : FoundationController
    {
        private UserDBContext db = new UserDBContext();
        test
        // GET: /Users/
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
    }
}