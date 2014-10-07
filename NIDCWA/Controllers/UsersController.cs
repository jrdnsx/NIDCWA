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
        // GET: /Users/
        public ActionResult Index()
        {
            //var users = from u in entities.User.ToList()
            //            select new UserBasicViewModel
            //            {
            //                username = u.Username
            //            };
            IEnumerable<UserBasicViewModel> users = from u in entities.User.ToList()
                                                    select new UserBasicViewModel
                                                    {
                                                        ID = u.ID,
                                                        username = u.Username,
                                                        active = u.Active
                                                    };
            return View("Index", users);
        }
    }
}