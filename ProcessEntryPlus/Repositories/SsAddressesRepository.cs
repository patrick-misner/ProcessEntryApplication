using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class SsAddressesRepository
    {

        private readonly MySqlConnection _db;

        public SsAddressesRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<SsAddress> GetAll()
        {
            string sql = @"
            SELECT *
            FROM ssAddresses
            ";
            return _db.Query<SsAddress>(sql).ToList();
        }

        internal SsAddress Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM ssAddresses
            WHERE id = @id
            ";
            return _db.Query<SsAddress>(sql, new { id }).FirstOrDefault();
        }

        internal SsAddress Create(SsAddress ssAddressData)
        {
            string sql = @"
            INSERT INTO ssAddresses
            (ssId, addressId)
            VALUES
            (@SsId, @AddressId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, ssAddressData);
            ssAddressData.Id = id;
            return ssAddressData;
        }

        internal void Edit(SsAddress original)
        {
            string sql = @"
            UPDATE ssAddresses
            SET
            ssId = @SsId,
            addressId = @AddressId
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM ssAddresses WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
