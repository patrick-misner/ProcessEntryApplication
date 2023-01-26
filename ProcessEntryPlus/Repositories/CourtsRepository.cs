using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySqlConnector;
using ProcessEntryPlus.Models;
using Dapper;

namespace ProcessEntryPlus.Repositories
{
  public class CourtsRepository
  {
    private readonly MySqlConnection _db;

    public CourtsRepository(MySqlConnection db)
    {
      _db = db;
    }

    internal List<Court> GetAll()
    {
      string sql = @"
      SELECT *
      FROM courts
      ";
      return _db.Query<Court>(sql).ToList();
    }

    internal Court Get(int id)
    {
      string sql = @"
      SELECT *
      FROM courts
      WHERE id = @id
      ";
      return _db.Query<Court>(sql, new { id }).FirstOrDefault();
    }

    internal Court Create(Court courtData)
    {
      string sql = @"
      INSERT INTO courts
      (name, addressLine1, addressLine2, city, state, zip, phone)
      VALUES
      (@Name, @AddressLine1, @AddressLine2, @City, @State, @Zip, @Phone);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, courtData);
      courtData.Id = id;
      return courtData;
    }

    internal void Edit(Court original)
    {
      string sql = @"
      UPDATE courts
      SET
      name = @Name,
      addressLine1 = @AddressLine1,
      addressLine2 = @AddressLine2,
      city = @City,
      state = @State,
      zip = @Zip,
      phone = @Phone
      WHERE id = @Id
      ";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM courts WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

  }
}