using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Prctice.Controllers
{
    public class CacheOutputController : Controller
    {
        // GET: CacheOutput
        [OutputCache(Duration = 10, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            return View();
        }
    }
}