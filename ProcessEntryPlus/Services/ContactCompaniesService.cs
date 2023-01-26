using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class ContactCompaniesService
  {
    private readonly ContactCompaniesRepository _repo;
    public ContactCompaniesService(ContactCompaniesRepository repo)
    {
      _repo = repo;
    }
    internal List<ContactCompany> GetAll()
    {
      return _repo.GetAll();
    }
    internal ContactCompany Get(int id)
    {
      ContactCompany found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal ContactCompany Create(ContactCompany contactCompanyData)
    {
      return _repo.Create(contactCompanyData);
    }
    internal ContactCompany Edit(ContactCompany contactCompanyData)
    {
      ContactCompany original = Get(contactCompanyData.Id);

      original.ContactId = contactCompanyData.ContactId ?? original.ContactId;
      original.CompanyId = contactCompanyData.CompanyId ?? original.CompanyId;

      _repo.Edit(original);
      return original;
    }
    internal ContactCompany Delete(int id)
    {
      ContactCompany original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}