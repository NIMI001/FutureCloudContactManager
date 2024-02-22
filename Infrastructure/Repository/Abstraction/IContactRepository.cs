using FutureCloudContactManager.Models;

namespace FutureCloudContactManager.Infrastructure.Repository.Abstraction
{
    public interface IContactRepository
    {
        IQueryable<Contact> GetAllUserContacts (string userId, string? search, string filter);
        Task AddContactAsync(Contact contact);
        Contact GetContactById(string Id);
        void DeleteContact(Contact contact);
        void UpdateContact(Contact contact);
        Task SaveChangesAsync();

    }
}
