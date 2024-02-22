namespace FutureCloudContactManager.Models
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime DateUploaded { get; set; } = DateTime.UtcNow.AddHours(1);
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow.AddHours(1);
    }
}
