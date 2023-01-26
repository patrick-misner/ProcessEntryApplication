using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class CapacitiesService
  {
    private readonly CapacitiesRepository _repo;
    public CapacitiesService(CapacitiesRepository repo)
    {
      _repo = repo;
    }
    internal List<Capacity> GetAll()
    {
      return _repo.GetAll();
    }
    internal Capacity Get(int id)
    {
      Capacity found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Capacity Create(Capacity capacityData)
    {
      return _repo.Create(capacityData);
    }
    internal Capacity Edit(Capacity capacityData)
    {
      Capacity original = Get(capacityData.Id);

      original.Position = capacityData.Position ?? original.Position;
      original.Name = capacityData.Name ?? original.Name;


      _repo.Edit(original);
      return original;
    }
    internal Capacity Delete(int id)
    {
      Capacity original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}