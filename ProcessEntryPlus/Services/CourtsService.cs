using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class CourtsService
  {
    private readonly CourtsRepository _repo;
    public CourtsService(CourtsRepository repo)
    {
      _repo = repo;
    }
    internal List<Court> GetAll()
    {
      return _repo.GetAll();
    }
    internal Court Get(int id)
    {
      Court found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Court Create(Court courtData)
    {
      return _repo.Create(courtData);
    }
    internal Court Edit(Court courtData)
    {
      Court original = Get(courtData.Id);

      original.Name = courtData.Name ?? original.Name;
      original.AddressLine1 = courtData.AddressLine1 ?? original.AddressLine1;
      original.AddressLine2 = courtData.AddressLine2 ?? original.AddressLine2;
      original.City = courtData.City ?? original.City;
      original.State = courtData.State ?? original.State;
      original.Zip = courtData.Zip ?? original.Zip;
      original.Phone = courtData.Phone ?? original.Phone;

      _repo.Edit(original);
      return original;
    }
    internal Court Delete(int id)
    {
      Court original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}