namespace ProcessEntryPlus.Models
{
    public class Server
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Boolean? IsActive { get; set; } = true;
        public string? Name { get; set; }
        public string? BarNumber { get; set; }
        public string? License { get; set; }
        public string? Street { get; set; }
        public string? CityStateZip { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set;}
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Notes { get; set; }
        public string? Mobile { get; set; }
    }
}
