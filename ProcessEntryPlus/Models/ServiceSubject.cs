namespace ProcessEntryPlus.Models
{
    public class ServiceSubject
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string? Picture { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Notes { get; set; }
        public string? Race { get; set; }
        public string? Sex { get; set; }
        public string? Age { get; set; }
        public string? Height { get; set; }
        public int? Weight { get; set; }
        public string? Hair { get; set; }
        public Boolean? Glasses { get; set; } = false;
        public string? DriversLicense { get; set; }
        public string? MilitaryStatus { get; set; } = "unknown";
    }
}
