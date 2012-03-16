using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using Mvc3Demo.Models;

namespace Mvc3Demo.Controllers {

    public class BasicController : DirectController {

        public ActionResult Echo(string text, DateTime date, Contact contact) {
            return Json(new {
                text,
                date,
                contact
            });
        }

        [NamedArguments]
        public ActionResult EchoNamedArgs(string text, DateTime date, Contact contact) {
            return Json(new {
                text,
                date,
                contact
            });
        }

        public ActionResult TestException() {
            var e = new DirectException("Oh no! Something bad happened!!!");
            e.Data.Add("stringInfo", "Additional string information.");
            e.Data["intInfo"] = -903;
            e.Data["dateTimeInfo"] = DateTime.Now;
            throw e;

            return Json("This line is never reached.");
        }
    }
}