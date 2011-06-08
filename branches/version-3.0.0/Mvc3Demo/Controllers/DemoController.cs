using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using Newtonsoft.Json.Converters;

namespace Mvc3Demo.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult EchoText(string text) {
            return this.Direct(text);
        }

        public ActionResult AddNumbers(int a, int b) {
            return this.Direct(a + b);
        }

        public ActionResult EchoPerson(Person p) {
            return this.Direct(p, new JavaScriptDateTimeConverter(), new StringEnumConverter());
        }

        public ActionResult FakeException() {
            var e = new DirectException("This statement is the original exception message.");
            e.Data.Add("stringInfo", "Additional string information.");
            e.Data["intInfo"] = -903;
            e.Data["dateTimeInfo"] = DateTime.Now;
            throw e;

            return this.Direct("This line is never reached.");
        }
    }
}
