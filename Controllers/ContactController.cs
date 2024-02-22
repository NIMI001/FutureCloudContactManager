using FutureCloudContactManager.Infrastructure.Repository.Abstraction;
using FutureCloudContactManager.Infrastructure.Repository.Implementation;
using FutureCloudContactManager.Models;
using FutureCloudContactManager.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FutureCloudContactManager.Controllers
{

    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController( IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        [HttpGet]
        public IActionResult AllContact(string search, string filter)
        {
            
            var userId = "5";
            var userContacts = _contactRepository.GetAllUserContacts(userId, search,filter);
            var userContactVMs = new List<ContactVM>();
            foreach (var contact in userContacts)
            {
                userContactVMs.Add(new ContactVM
                {
                    Id= contact.Id,
                    ContactName= contact.ContactName,
                    Email = contact.Email,
                    CountryCode = contact.CountryCode,
                    Phonenumber = contact.Phonenumber,
                    Address = contact.Address,
                });
            }
            return View(userContactVMs);
        }

        // Post: ContactController/AddNew
        [HttpPost]
        public async Task<IActionResult> AddContact(ContactVM contactVM)
        {
            var userId = "5"; //User.FindFirst();
            var contact = new Contact
            {
                ContactName = contactVM.ContactName,
                Email= contactVM.Email,
                CountryCode = contactVM.CountryCode,
                Phonenumber = contactVM.Phonenumber,
                Address = contactVM.Address,
                UserId = userId
            };
           await _contactRepository.AddContactAsync(contact);
           await _contactRepository.SaveChangesAsync();
            return RedirectToAction(nameof(AllContact));
        }

        // GET: ContactController/Search
        

        // GET: ContactController/Create
        public ActionResult AddNew()
        {
            return View();
        }

        
        

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
