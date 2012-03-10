using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc3Demo.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }

        public ViewResult ExtJS3() {
            return View();
        }

        public ViewResult ExtJS4() {
            return View();
        }

        public ViewResult Touch() {
            return View();
        }
    }
}
