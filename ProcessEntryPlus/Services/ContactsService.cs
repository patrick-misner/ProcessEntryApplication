using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class ContactsService
  {
    private readonly ContactsRepository _repo;
    public ContactsService(ContactsRepository repo)
    {
      _repo = repo;
    }
    internal List<Contact> GetAll()
    {
      return _repo.GetAll();
    }
    internal Contact Get(int id)
    {
      Contact found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Contact Create(Contact contactData)
    {
      return _repo.Create(contactData);
    }
    internal Contact Edit(Contact contactData)
    {
      Contact original = Get(contactData.Id);

      original.IsActive = contactData.IsActive ?? original.IsActive;
      original.Name = contactData.Name ?? original.Name;
      original.BarNumber= contactData.BarNumber ?? original.BarNumber;
      original.License = contactData.License ?? original.License;
      original.Street = contactData.Street ?? original.Street;
      original.CityStateZip = contactData.CityStateZip ?? original.CityStateZip;
      original.AddressLine1 = contactData.AddressLine1 ?? original.AddressLine1;
      original.AddressLine2 = contactData.AddressLine2 ?? original.AddressLine2;
      original.State = contactData.State ?? original.State;
      original.City = contactData.City ?? original.City;
      original.Zip = contactData.Zip ?? original.Zip;
      original.Phone = contactData.Phone ?? original.Phone;
      original.Fax = contactData.Fax ?? original.Fax;
      original.Email = contactData.Email ?? original.Email;
      original.Website = contactData.Website ?? original.Website;
      original.Notes = contactData.Notes ?? original.Notes;
      original.Mobile = contactData.Mobile ?? original.Mobile;

      _repo.Edit(original);
      return original;
    }
    internal Contact Delete(int id)
    {
      Contact original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}