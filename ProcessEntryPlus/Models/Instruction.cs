namespace ProcessEntryPlus.Models
{
    public class Instruction
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Position { get; set; }
        public string? Name { get; set; }
    }

}
