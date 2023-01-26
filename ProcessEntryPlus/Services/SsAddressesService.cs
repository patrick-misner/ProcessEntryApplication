using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class SsAddressesService
  {
    private readonly SsAddressesRepository _repo;
    public SsAddressesService(SsAddressesRepository repo)
    {
      _repo = repo;
    }
    internal List<SsAddress> GetAll()
    {
      return _repo.GetAll();
    }
    internal SsAddress Get(int id)
    {
      SsAddress found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal SsAddress Create(SsAddress ssAddressData)
    {
      return _repo.Create(ssAddressData);
    }
    internal SsAddress Edit(SsAddress ssAddressData)
    {
      SsAddress original = Get(ssAddressData.Id);

      original.SsId = ssAddressData.SsId ?? original.SsId;
      original.AddressId = ssAddressData.AddressId ?? original.AddressId;

      _repo.Edit(original);
      return original;
    }
    internal SsAddress Delete(int id)
    {
      SsAddress original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}