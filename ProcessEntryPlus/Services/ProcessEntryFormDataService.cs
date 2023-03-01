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
      return processEntryFormData;
    }
  }
}

