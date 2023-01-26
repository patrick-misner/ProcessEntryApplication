using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class AffidavitTypesService
  {
    private readonly AffidavitTypesRepository _repo;
    public AffidavitTypesService(AffidavitTypesRepository repo)
    {
      _repo = repo;
    }
    internal List<AffidavitType> GetAll()
    {
      return _repo.GetAll();
    }
    internal AffidavitType Get(int id)
    {
      AffidavitType found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal AffidavitType Create(AffidavitType affidavitTypeData)
    {
      return _repo.Create(affidavitTypeData);
    }
    internal AffidavitType Edit(AffidavitType affidavitTypeData)
    {
      AffidavitType original = Get(affidavitTypeData.Id);

      original.Position = affidavitTypeData.Position ?? original.Position;
      original.Name = affidavitTypeData.Name ?? original.Name;


      _repo.Edit(original);
      return original;
    }
    internal AffidavitType Delete(int id)
    {
      AffidavitType original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}