using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class ContactsRepository
    {

        private readonly MySqlConnection _db;

        public ContactsRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<Contact> GetAll()
        {
            string sql = @"
            SELECT *
            FROM contacts
            ";
            return _db.Query<Contact>(sql).ToList();
        }

        internal Contact Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM contacts
            WHERE id = @id
            ";
            return _db.Query<Contact>(sql, new { id }).FirstOrDefault();
        }

        internal Contact Create(Contact contactData)
        {
            string sql = @"
            INSERT INTO contacts
            (isActive, name, barNumber, license, street, cityStateZip, addressLine1, addressLine2, state, city, zip, phone, fax, email, website, notes, mobile)
            VALUES
            (@IsActive, @Name, @BarNumber, @License, @Street, @CityStateZip, @AddressLine1, @AddressLine2, @State, @City, @Zip, @Phone, @Fax, @Email, @Website, @Notes, @Mobile);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, contactData);
            contactData.Id = id;
            return contactData;
        }

        internal void Edit(Contact original)
        {
            string sql = @"
            UPDATE contacts
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
            string sql = "DELETE FROM contacts WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
