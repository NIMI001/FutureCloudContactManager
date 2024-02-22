using FutureCloudContactManager.Infrastructure.Persistent;
using FutureCloudContactManager.Infrastructure.Repository.Abstraction;
using FutureCloudContactManager.Models;

namespace FutureCloudContactManager.Infrastructure.Repository.Implementation
{

    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _contactContext;
        public ContactRepository(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }
       

        public async Task AddContactAsync(Contact contact)
        {
           await _contactContext.Contacts.AddAsync(contact);

        }

        public void DeleteContact(Contact contact)
        {
            _contactContext.Contacts.Remove(contact);
        }


        public IQueryable<Contact> GetAllUserContacts(string userId, string? search)
        {
           var contacts = _contactContext.Contacts.Where(c=>c.UserId==userId);
           if(string.IsNullOrEmpty(search) )
            {
                return contacts;
            }
           return contacts.Where(c=>c.ContactName.Contains(search) || 
           c.Email.Contains(search) || c.Phonenumber.Contains(search));
        }

        public Contact GetContactById(string Id)
        {
            return _contactContext.Contacts.SingleOrDefault(c => c.Id == Id);
        }

        public async Task SaveChangesAsync()
        {
            await _contactContext.SaveChangesAsync();
        }

        public void UpdateContact(Contact contact)
        {
            _contactContext.Contacts.Update(contact);
        }

       
    }
}
