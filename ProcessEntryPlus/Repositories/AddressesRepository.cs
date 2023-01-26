using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
  public class AddressesRepository
  {

    private readonly MySqlConnection _db;

    public AddressesRepository(MySqlConnection db)
    {
      _db = db;
    }

    internal List<Address> GetAll()
    {
      string sql = @"
            SELECT *
            FROM addresses
            ";
      return _db.Query<Address>(sql).ToList();
    }

    internal Address Get(int id)
    {
      string sql = @"
            SELECT *
            FROM addresses
            WHERE id = @id
            ";
      return _db.Query<Address>(sql, new { id }).FirstOrDefault();
    }

    internal Address Create(Address addressData)
    {
      string sql = @"
            INSERT INTO addresses
            (fullAddress, addressLine1, addressLine2, city, state, zip, location)
            VALUES
            (@FullAddress, @AddressLine1, @AddressLine2, @City, @State, @Zip, @Location);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, addressData);
      addressData.Id = id;
      return addressData;
    }

    internal void Edit(Address original)
    {
      string sql = @"
            UPDATE addresses
            SET
            fullAddress = @FullAddress,
            addressLine1 = @AddressLine1,
            addressLine2 = @AddressLine2,
            city = @City,
            state = @State,
            zip = @Zip,
            location = @Location
            WHERE id = @Id
            ";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM addresses WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}
