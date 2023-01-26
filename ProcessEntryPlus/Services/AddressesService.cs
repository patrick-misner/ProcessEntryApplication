using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;


namespace ProcessEntryPlus.Services
{
    public class AddressesService
    {

        private readonly AddressesRepository _repo;

        public AddressesService(AddressesRepository repo)
        {
            _repo = repo;
        }

        internal List<Address> GetAll()
        {
            return _repo.GetAll();
        }

        internal Address Get(int id) 
        {
            Address found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Address Create(Address addressData)
        {
            return _repo.Create(addressData);
        }

        internal Address Edit(Address addressData) 
        {
            Address original = Get(addressData.Id);

            original.FullAddress = addressData.FullAddress ?? original.FullAddress;
            original.AddressLine1 = addressData.AddressLine1 ?? original.AddressLine1;
            original.AddressLine2 = addressData.AddressLine2 ?? original.AddressLine2;
            original.City = addressData.City ?? original.City;
            original.State = addressData.State ?? original.State;
            original.Zip = addressData.Zip ?? original.Zip;
            original.Location = addressData.Location ?? original.Location;

            _repo.Edit(original);
            return original;
        }


        internal Address Delete(int id)
        {
            Address original = Get(id);
            if (original == null)
            {
                throw new Exception("Delete failed. Invalid Id");
            }
            _repo.Delete(id);
            return original;
        }
    }
}
