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
    internal List<ProcessEntryFormData> GetAll()
    {
      List<ProcessEntryFormData> courtFormData = _repo.GetCourts();
      List<ProcessEntryFormData> litigantTypeFormData = _repo.GetLitigantTypes();
      List<ProcessEntryFormData> processEntryFormData = courtFormData.Concat(litigantTypeFormData).ToList();
      return processEntryFormData;
    }

  }
}

