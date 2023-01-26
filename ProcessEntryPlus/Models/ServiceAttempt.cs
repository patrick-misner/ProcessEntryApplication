namespace ProcessEntryPlus.Models
{
    public class ServiceAttempt
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? PeId { get; set; }
        public DateTime? AttemptDateTime { get; set; }
        public string? Comment { get; set; }
        public int? AddrId { get; set; }
    }
}
