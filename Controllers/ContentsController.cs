using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContentsController : Controller
    {
        // GET: Contents
        public ActionResult Index()
        {
            return View();
        }
    }
}