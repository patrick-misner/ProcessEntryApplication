using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class CompaniesRepository
    {

        private readonly MySqlConnection _db;

        public CompaniesRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<Company> GetAll()
        {
            string sql = @"
            SELECT *
            FROM companies
            ";
            return _db.Query<Company>(sql).ToList();
        }

        internal Company Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM companies
            WHERE id = @id
            ";
            return _db.Query<Company>(sql, new { id }).FirstOrDefault();
        }

        internal Company Create(Company companyData)
        {
            string sql = @"
            INSERT INTO companies
            (isActive, name, barNumber, license, street, cityStateZip, addressLine1, addressLine2, state, city, zip, phone, fax, email, website, notes, taxId, mobile)
            VALUES
            (@IsActive, @Name, @BarNumber, @License, @Street, @CityStateZip, @AddressLine1, @AddressLine2, @State, @City, @Zip, @Phone, @Fax, @Email, @Website, @Notes, @TaxId, @Mobile);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, companyData);
            companyData.Id = id;
            return companyData;
        }

        internal void Edit(Company original)
        {
            string sql = @"
            UPDATE companies
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
            taxId = @TaxId,
            mobile = @Mobile
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM companies WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
