namespace FutureCloudContactManager.Models
{
    public class Contact:BaseEntity
    {

        public string ?ContactName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string  UserId { get; set; }
    }
}
