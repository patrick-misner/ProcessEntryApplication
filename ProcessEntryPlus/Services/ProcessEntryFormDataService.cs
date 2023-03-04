using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;


namespace ProcessEntryPlus.Services
{
  public class ProcessEntryFormDataService
  {
    private readonly ProcessEntryFormDataRepository _repo;
    public ProcessEntryFormDataService(ProcessEntryFormDataRepository repo)
    {
      _repo = repo;
    }
    internal ProcessEntryFormData Get()
    {
      ProcessEntryFormData processEntryFormData = new ProcessEntryFormData();
      processEntryFormData.Courts = _repo.GetCourts();
      processEntryFormData.LitigantTypes = _repo.GetLitigantTypes();
      processEntryFormData.Documents = _repo.GetDocuments();
      processEntryFormData.Instructions = _repo.GetInstructions();
      processEntryFormData.Servers = _repo.GetServers();
      processEntryFormData.Methods = _repo.GetMethods();
      processEntryFormData.Capacities = _repo.GetCapacities();
      processEntryFormData.AffidavitTypes = _repo.GetAffidavitTypes();
      return processEntryFormData;
    }
  }
}

