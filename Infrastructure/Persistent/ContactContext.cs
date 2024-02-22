using FutureCloudContactManager.Infrastructure.Configuration;
using FutureCloudContactManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FutureCloudContactManager.Infrastructure.Persistent
{
    public class ContactContext : IdentityDbContext
    {
        public ContactContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RolesConfig());
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
