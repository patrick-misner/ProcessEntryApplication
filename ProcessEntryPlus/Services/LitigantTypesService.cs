using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class LitigantTypesService
  {
    private readonly LitigantTypesRepository _repo;
    public LitigantTypesService(LitigantTypesRepository repo)
    {
      _repo = repo;
    }
    internal List<LitigantType> GetAll()
    {
      return _repo.GetAll();
    }
    internal LitigantType Get(int id)
    {
      LitigantType found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal LitigantType Create(LitigantType litigantTypeData)
    {
      return _repo.Create(litigantTypeData);
    }
    internal LitigantType Edit(LitigantType litigantTypeData)
    {
      LitigantType original = Get(litigantTypeData.Id);

      original.Position = litigantTypeData.Position ?? original.Position;
      original.Name = litigantTypeData.Name ?? original.Name;


      _repo.Edit(original);
      return original;
    }
    internal LitigantType Delete(int id)
    {
      LitigantType original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}