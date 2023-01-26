namespace ProcessEntryPlus.Models
{
    public class ProcessEntry
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CaseNum { get; set; }
        public int? CourtId { get; set; }
        public Court? Court { get; set; }
        public string? Status { get; set; } = "Active";
        public string? Priority { get; set; } = "Routine";
        public DateTime? ExpireDateTime { get; set; }
        public int? PlaintiffTypeId { get; set; }
        public LitigantType? PlaintiffType { get; set; }
        public string? Plaintiff { get; set; }
        public int? DefendantTypeId { get; set; }
        public LitigantType? DefendantType { get; set; }
        public string? Defendant { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public int? ContactId { get; set; }
        public Contact? Contact { get; set; }
        public DateTime? ReceivedDateTime { get; set; }
        public int? DocumentId { get; set; }
        public Document? Document { get; set; }
        public int? SsId { get; set; }
        public ServiceSubject? ServiceSubject { get; set; }
        public int? ServeToAddrId1 { get; set; }
        public Address? ServeToAddr1 { get; set; }
        public int? ServeToAddrId2 { get; set; }
        public Address? ServeToAddr2 { get; set; }
        public int? InstructionId { get; set; }
        public Instruction? Instruction { get; set; }
        public int? ServerId { get; set; }
        public Server? Server { get; set; }
        public string? ClientRef { get; set; }
        public DateTime? ServedDateTime { get; set; }
        public int? MethodId { get; set; }
        public Method? Method {get; set; }
        public string? SubServed { get; set; }
        public int? CapacityId { get; set; }
        public Capacity? Capacity { get; set; }
        public int? ServedAddrId { get; set; }
        public Address? ServedAddr { get; set; }
        public string? Comments { get; set; }
        public int? AffidavitTypeId { get; set; }
        public AffidavitType? AffidavitType { get; set; }
        public string? DueDiligence { get; set; }
        public int? ServiceAttempts { get; set; }
        public int? PhysDesc { get; set; }
        public int? AffidavitFee { get; set; }
        public float? ServiceFee { get; set; }
    }
}





