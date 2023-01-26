using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class CompaniesService
  {
    private readonly CompaniesRepository _repo;
    public CompaniesService(CompaniesRepository repo)
    {
      _repo = repo;
    }
    internal List<Company> GetAll()
    {
      return _repo.GetAll();
    }
    internal Company Get(int id)
    {
      Company found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Company Create(Company companyData)
    {
      return _repo.Create(companyData);
    }
    internal Company Edit(Company companyData)
    {
      Company original = Get(companyData.Id);

      original.IsActive = companyData.IsActive ?? original.IsActive;
      original.Name = companyData.Name ?? original.Name;
      original.BarNumber= companyData.BarNumber ?? original.BarNumber;
      original.License = companyData.License ?? original.License;
      original.Street = companyData.Street ?? original.Street;
      original.CityStateZip = companyData.CityStateZip ?? original.CityStateZip;
      original.AddressLine1 = companyData.AddressLine1 ?? original.AddressLine1;
      original.AddressLine2 = companyData.AddressLine2 ?? original.AddressLine2;
      original.State = companyData.State ?? original.State;
      original.City = companyData.City ?? original.City;
      original.Zip = companyData.Zip ?? original.Zip;
      original.Phone = companyData.Phone ?? original.Phone;
      original.Fax = companyData.Fax ?? original.Fax;
      original.Email = companyData.Email ?? original.Email;
      original.Website = companyData.Website ?? original.Website;
      original.Notes = companyData.Notes ?? original.Notes;
      original.TaxId = companyData.TaxId ?? original.TaxId;
      original.Mobile = companyData.Mobile ?? original.Mobile;

      _repo.Edit(original);
      return original;
    }
    internal Company Delete(int id)
    {
      Company original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}