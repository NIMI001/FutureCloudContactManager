using Microsoft.AspNetCore.Mvc;

namespace FutureCloudContactManager.Models.ViewModel
{
    public class ContactVM
    {
        public string Id { get; set; } 
        public DateTime DateUploaded { get; set; } 
        public DateTime DateUpdated { get; set; } 
        public string? ContactName { get; set; }
        public string ?Email { get; set; } 
        public string ?CountryCode { get; set; } 
        public string ?Phonenumber { get; set; } 
        public string ?Address { get; set; } 
    }
}
