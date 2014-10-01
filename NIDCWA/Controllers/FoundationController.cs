using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NIDCWA.Controllers
{
    public class FoundationController : Controller
    {
        protected NECCaptran_DevEntities entities;

        protected FoundationController()
        {
            entities = new NECCaptran_DevEntities();
        }
    }
}