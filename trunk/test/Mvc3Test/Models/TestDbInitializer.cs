using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mvc3Test.Models {

    public class TestDbInitializer : DropCreateDatabaseAlways<TestDbContext> {

        protected override void Seed(TestDbContext context) {
            var contacts = new List<Contact> {
                new Contact { FirstName = "Carson",   LastName = "Alexander", Email="calexander@mail.com",  BirthDate = DateTime.Parse("1976-09-01"), IsFavourite=false },
                new Contact { FirstName = "Meredith", LastName = "Alonso",    Email="malonso@email.com",    BirthDate = DateTime.Parse("1980-02-15"), IsFavourite=false },
                new Contact { FirstName = "Arturo",   LastName = "Anand",     Email="aanand@email.com",     BirthDate = DateTime.Parse("1969-05-24"), IsFavourite=false },
                new Contact { FirstName = "Gytis",    LastName = "Barzdukas", Email="gbarzdukas@email.com", BirthDate = DateTime.Parse("1973-09-20"), IsFavourite=false },
                new Contact { FirstName = "Yan",      LastName = "Li",        Email="yanli@email.com",      BirthDate = DateTime.Parse("1975-11-01"), IsFavourite=false },
                new Contact { FirstName = "Peggy",    LastName = "Justice",   Email="pjustice@email.com",   BirthDate = DateTime.Parse("1964-01-14"), IsFavourite=false },
                new Contact { FirstName = "Laura",    LastName = "Norman",    Email="lnorman@email.com",    BirthDate = DateTime.Parse("2001-08-03"), IsFavourite=false },
                new Contact { FirstName = "Nino",     LastName = "Olivetto",  Email="nolivetto@email.com",  BirthDate = DateTime.Parse("1984-03-17"), IsFavourite=false }
            };
            contacts.ForEach(c => context.Contacts.Add(c));
            context.SaveChanges();
        }
    }
}