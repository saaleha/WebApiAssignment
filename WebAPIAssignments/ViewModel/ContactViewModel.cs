using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIAssignments.Models;

namespace WebAPIAssignments.ViewModel
{
    public class ContactViewModel
    {
        public IEnumerable<RegistrationDetail> Details {get;set; }
        public ContactModel NewContact { get; set; }
    }
}