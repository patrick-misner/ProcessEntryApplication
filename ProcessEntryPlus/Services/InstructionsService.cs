using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class InstructionsService
  {
    private readonly InstructionsRepository _repo;
    public InstructionsService(InstructionsRepository repo)
    {
      _repo = repo;
    }
    internal List<Instruction> GetAll()
    {
      return _repo.GetAll();
    }
    internal Instruction Get(int id)
    {
      Instruction found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Instruction Create(Instruction instructionData)
    {
      return _repo.Create(instructionData);
    }
    internal Instruction Edit(Instruction instructionData)
    {
      Instruction original = Get(instructionData.Id);

      original.Position = instructionData.Position ?? original.Position;
      original.Name = instructionData.Name ?? original.Name;


      _repo.Edit(original);
      return original;
    }
    internal Instruction Delete(int id)
    {
      Instruction original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}