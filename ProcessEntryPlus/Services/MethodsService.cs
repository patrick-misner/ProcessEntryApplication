using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class MethodsService
  {
    private readonly MethodsRepository _repo;
    public MethodsService(MethodsRepository repo)
    {
      _repo = repo;
    }
    internal List<Method> GetAll()
    {
      return _repo.GetAll();
    }
    internal Method Get(int id)
    {
      Method found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Method Create(Method methodData)
    {
      return _repo.Create(methodData);
    }
    internal Method Edit(Method methodData)
    {
      Method original = Get(methodData.Id);

      original.Position = methodData.Position ?? original.Position;
      original.Name = methodData.Name ?? original.Name;


      _repo.Edit(original);
      return original;
    }
    internal Method Delete(int id)
    {
      Method original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}