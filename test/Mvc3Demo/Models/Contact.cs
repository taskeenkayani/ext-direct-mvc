using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc3Demo.Models {

    public class Contact {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsFavourite { get; set; }
    }
}