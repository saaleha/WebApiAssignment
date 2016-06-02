using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPIAssignments.Interfaces;
using WebAPIAssignments.Repository;
using WebAPIAssignments.ViewModel;
using WebAPIAssignments.Models;
using System.Data.Entity;

namespace WebAPIAssignments.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        //Async emplimentation
        private readonly IContactRepository _ContactRepository;
        public ContactController()
        {
            _ContactRepository = new ContactRepository();
        }
        [HttpGet]
        [AsyncTimeout(8000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimedOut")]
        public async Task<ActionResult> ContactDetails(CancellationToken cancellationtoken)
        {
            ContactViewModel List = new ContactViewModel()
            {
                NewContact = new ContactModel()
            };
            List.Details = await _ContactRepository.GetAllAsync(cancellationtoken);
            return View(List);
        }
        [HttpPost]
        [AsyncTimeout(2000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimedOut")]
        public async Task<ActionResult> Create(ContactModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (ModelState.IsValid)
            {
                RegistrationDetail reg = new RegistrationDetail()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone

                };
                await _ContactRepository.CreateAsync(reg, cancellationToken);
                return RedirectToAction("ContactDetails");
            }
            ContactViewModel viewmode = new ContactViewModel()
            {
                NewContact = new ContactModel()
            };
            viewmode.Details = await _ContactRepository.GetAllAsync(cancellationToken);
            return View("ContactDetails", viewmode);
        }
        [HttpGet]
        [AsyncTimeout(2000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimedOut")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _ContactRepository.DeleteAsync(id, cancellationToken);
            return RedirectToAction("ContactDetails");
        }

    }
}
