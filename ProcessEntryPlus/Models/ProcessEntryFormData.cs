namespace ProcessEntryPlus.Models
{
  public class ProcessEntryFormData
  {
    public List<ProcessEntryFormField>? Courts { get; set; }
    public List<ProcessEntryFormField>? LitigantTypes { get; set; }
    public List<ProcessEntryFormField>? Documents { get; set; }
    public List<ProcessEntryFormField>? Instructions { get; set; }
    public List<ProcessEntryFormField>? Servers { get; set; }
    public List<ProcessEntryFormField>? Methods { get; set; }
    public List<ProcessEntryFormField>? Capacities { get; set; }
    public List<ProcessEntryFormField>? AffidavitTypes { get; set; }

  }
}
