using System;
using System.Collections.Generic;
using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
  public class ServiceSubjectsService
  {
    private readonly ServiceSubjectsRepository _repo;
    public ServiceSubjectsService(ServiceSubjectsRepository repo)
    {
      _repo = repo;
    }
    internal List<ServiceSubject> GetAll()
    {
      return _repo.GetAll();
    }
    internal ServiceSubject Get(int id)
    {
      ServiceSubject found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal ServiceSubject Create(ServiceSubject serviceSubjectData)
    {
      return _repo.Create(serviceSubjectData);
    }
    internal ServiceSubject Edit(ServiceSubject serviceSubjectData)
    {

            ServiceSubject original = Get(serviceSubjectData.Id);

            original.Name = serviceSubjectData.Name ?? original.Name;
            original.Dob = serviceSubjectData.Dob ?? original.Dob;
            original.Picture = serviceSubjectData.Picture ?? original.Picture;
            original.Phone = serviceSubjectData.Phone ?? original.Phone;
            original.Mobile = serviceSubjectData.Mobile ?? original.Mobile;
            original.Fax = serviceSubjectData?.Fax ?? original.Fax;
            original.Email = serviceSubjectData.Email ?? original.Email;
            original.Website = serviceSubjectData.Website ?? original.Website;
            original.Notes = serviceSubjectData.Notes ?? original.Notes;
            original.Race = serviceSubjectData.Race ?? original.Race;
            original.Sex = serviceSubjectData.Sex ?? original.Sex;
            original.Age = serviceSubjectData.Age ?? original.Age;
            original.Height = serviceSubjectData.Height ?? original.Height;
            original.Weight = serviceSubjectData.Weight ?? original.Weight;
            original.Hair = serviceSubjectData.Hair ?? original.Hair;
            original.Glasses = serviceSubjectData.Glasses ?? original.Glasses;
            original.DriversLicense = serviceSubjectData.DriversLicense ?? original.DriversLicense;
            original.MilitaryStatus = serviceSubjectData.MilitaryStatus ?? original.MilitaryStatus;

            _repo.Edit(original);
            return original;
    }
    internal ServiceSubject Delete(int id)
    {
      ServiceSubject original = Get(id);
      if (original == null)
      {
        throw new Exception("Delete failed. Invalid Id");
      }
      _repo.Delete(id);
      return original;
    }
  }
}