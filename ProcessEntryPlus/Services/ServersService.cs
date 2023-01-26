using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class ServersService
  {
    private readonly ServersRepository _repo;
    public ServersService(ServersRepository repo)
    {
      _repo = repo;
    }
    internal List<Server> GetAll()
    {
      return _repo.GetAll();
    }
    internal Server Get(int id)
    {
      Server found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Server Create(Server serverData)
    {
      return _repo.Create(serverData);
    }
    internal Server Edit(Server serverData)
    {
      Server original = Get(serverData.Id);

      original.IsActive = serverData.IsActive ?? original.IsActive;
      original.Name = serverData.Name ?? original.Name;
      original.BarNumber= serverData.BarNumber ?? original.BarNumber;
      original.License = serverData.License ?? original.License;
      original.Street = serverData.Street ?? original.Street;
      original.CityStateZip = serverData.CityStateZip ?? original.CityStateZip;
      original.AddressLine1 = serverData.AddressLine1 ?? original.AddressLine1;
      original.AddressLine2 = serverData.AddressLine2 ?? original.AddressLine2;
      original.State = serverData.State ?? original.State;
      original.City = serverData.City ?? original.City;
      original.Zip = serverData.Zip ?? original.Zip;
      original.Phone = serverData.Phone ?? original.Phone;
      original.Fax = serverData.Fax ?? original.Fax;
      original.Email = serverData.Email ?? original.Email;
      original.Website = serverData.Website ?? original.Website;
      original.Notes = serverData.Notes ?? original.Notes;
      original.Mobile = serverData.Mobile ?? original.Mobile;

      _repo.Edit(original);
      return original;
    }
    internal Server Delete(int id)
    {
      Server original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}