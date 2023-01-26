using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class ServiceAttemptsService
  {
    private readonly ServiceAttemptsRepository _repo;
    public ServiceAttemptsService(ServiceAttemptsRepository repo)
    {
      _repo = repo;
    }
    internal List<ServiceAttempt> GetAll()
    {
      return _repo.GetAll();
    }
    internal ServiceAttempt Get(int id)
    {
      ServiceAttempt found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal ServiceAttempt Create(ServiceAttempt serviceAttemptData)
    {
      return _repo.Create(serviceAttemptData);
    }
    internal ServiceAttempt Edit(ServiceAttempt serviceAttemptData)
    {
      ServiceAttempt original = Get(serviceAttemptData.Id);

      original.PeId = serviceAttemptData.PeId ?? original.PeId;
      original.AttemptDateTime = serviceAttemptData.AttemptDateTime ?? original.AttemptDateTime;
      original.Comment = serviceAttemptData.Comment ?? original.Comment;
      original.AddrId= serviceAttemptData.AddrId ?? original.AddrId;

      _repo.Edit(original);
      return original;
    }
    internal ServiceAttempt Delete(int id)
    {
      ServiceAttempt original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}