using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using Mvc3Demo.Models;

namespace Mvc3Demo.Controllers {

    public class ContactController : DirectController {

        private readonly TestDbContext db = new TestDbContext();

        public ActionResult List() {
            System.Threading.Thread.Sleep(2000);
            return Json(db.Contacts.ToList());
        }

        public DirectResult Get(int id) {
            Contact contact = db.Contacts.Single(c => c.ID == id);
            return Json(contact);
        }

        public DirectResult Create(Contact contact) {
            if (ModelState.IsValid) {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return Json(new {
                    success = true
                });
            }

            return Json(new {
                success = false
            });
        }

        public DirectResult Update(Contact contact) {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
            return Json(db.Contacts.Find(contact.ID));
        }

        public DirectResult Delete(int id) {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return Json(true);
        }

        protected override void Dispose(bool disposing) {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}