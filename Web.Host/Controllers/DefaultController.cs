using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UIProcess;

namespace Web.Host.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}