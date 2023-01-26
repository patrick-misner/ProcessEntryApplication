using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class ServersRepository
    {

        private readonly MySqlConnection _db;

        public ServersRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<Server> GetAll()
        {
            string sql = @"
            SELECT *
            FROM servers
            ";
            return _db.Query<Server>(sql).ToList();
        }

        internal Server Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM servers
            WHERE id = @id
            ";
            return _db.Query<Server>(sql, new { id }).FirstOrDefault();
        }

        internal Server Create(Server serverData)
        {
            string sql = @"
            INSERT INTO servers
            (isActive, name, barNumber, license, street, cityStateZip, addressLine1, addressLine2, state, city, zip, phone, fax, email, website, notes, mobile)
            VALUES
            (@IsActive, @Name, @BarNumber, @License, @Street, @CityStateZip, @AddressLine1, @AddressLine2, @State, @City, @Zip, @Phone, @Fax, @Email, @Website, @Notes, @Mobile);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, serverData);
            serverData.Id = id;
            return serverData;
        }

        internal void Edit(Server original)
        {
            string sql = @"
            UPDATE servers
            SET
            isActive = @IsActive,
            name = @Name,
            barNumber = @BarNumber,
            license = @License,
            street = @Street,
            cityStateZip = @CityStateZip,
            addressLine1 = @AddressLine1,
            addressLine2 = @AddressLine2,
            state = @State,
            city = @City,
            zip = @Zip,
            phone = @Phone,
            fax = @Fax,
            email = @Email,
            website = @Website,
            notes = @Notes,
            mobile = @Mobile
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM servers WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
