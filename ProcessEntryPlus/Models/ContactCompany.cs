namespace ProcessEntryPlus.Models
{
    public class ContactCompany
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ContactId { get; set; }
        public int? CompanyId { get; set; }
    }
}
