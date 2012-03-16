using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using Mvc3Demo.Models;
using Newtonsoft.Json.Converters;

namespace Mvc3Demo.Controllers {

    public class FormController : DirectController {

        private readonly TestDbContext db = new TestDbContext();

        [ActionName("LoadContact")] // Action alias
        public ActionResult LoadForm(int id) {
            var contact = db.Contacts.Single(c => c.ID == id);
            return Json(new {
                success = true,
                data = contact
            });
        }

        [FormHandler]
        [ActionName("SaveContact")] // Action alias
        public ActionResult SaveForm(Contact contact) {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new {
                success = true,
                data = contact
            });
        }

        [FormHandler]
        public ActionResult Upload() {
            var files = Request.Files;

            foreach (string file in files) {
                HttpPostedFileBase hpf = files[file];
                if (hpf.ContentLength == 0)
                    continue;
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploaded Files");
                string savedFileName = Path.Combine(folderPath, Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);
            }

            return Json(new { success = true });
        }

    }
}
