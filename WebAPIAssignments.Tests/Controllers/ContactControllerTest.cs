using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebAPIAssignments.Interfaces;
using WebAPIAssignments.Repository;
using WebAPIAssignments.ViewModel;
using WebAPIAssignments.Models;

namespace WebAPIAssignments.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTest
    {
        private Mock<IContactRepository> _Contact;
        public ContactControllerTest()
        {
            _Contact = new Mock<IContactRepository>();
        }
         
        [TestMethod]
        public void ContactDetailsTest()
        {
            ContactViewModel List = new ContactViewModel()
            {
                NewContact = new ContactModel()
            };
            //List.Details=_Contact.E
            
        }
    }
}
