using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class DocumentsService
  {
    private readonly DocumentsRepository _repo;
    public DocumentsService(DocumentsRepository repo)
    {
      _repo = repo;
    }
    internal List<Document> GetAll()
    {
      return _repo.GetAll();
    }
    internal Document Get(int id)
    {
      Document found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Document Create(Document documentData)
    {
      return _repo.Create(documentData);
    }
    internal Document Edit(Document documentData)
    {
      Document original = Get(documentData.Id);

      original.Position = documentData.Position ?? original.Position;
      original.Name = documentData.Name ?? original.Name;


      _repo.Edit(original);
      return original;
    }
    internal Document Delete(int id)
    {
      Document original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}