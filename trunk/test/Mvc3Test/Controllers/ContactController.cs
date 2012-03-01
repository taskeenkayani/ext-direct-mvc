using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using Mvc3Test.Models;

namespace Mvc3Test.Controllers {

    public class ContactController : DirectController {

        private readonly TestDbContext db = new TestDbContext();

        public DirectResult List() {
            return Direct(db.Contacts.ToList());
        }

        public DirectResult Get(int id) {
            Contact contact = db.Contacts.Find(id);
            return Direct(contact);
        }

        [HttpPost]
        public DirectResult Create(Contact contact) {
            if (ModelState.IsValid) {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return Direct(new {
                    success = true
                });
            }

            return Direct(new {
                success = false
            });
        }

        public DirectResult Delete(int id) {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return Direct(true);
        }

        protected override void Dispose(bool disposing) {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}