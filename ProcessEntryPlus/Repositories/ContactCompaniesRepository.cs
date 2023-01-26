using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class ContactCompaniesRepository
    {

        private readonly MySqlConnection _db;

        public ContactCompaniesRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<ContactCompany> GetAll()
        {
            string sql = @"
            SELECT *
            FROM contactCompanies
            ";
            return _db.Query<ContactCompany>(sql).ToList();
        }

        internal ContactCompany Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM contactCompanies
            WHERE id = @id
            ";
            return _db.Query<ContactCompany>(sql, new { id }).FirstOrDefault();
        }

        internal ContactCompany Create(ContactCompany contactCompanyData)
        {
            string sql = @"
            INSERT INTO contactCompanies
            (contactId, companyId)
            VALUES
            (@ContactId, @CompanyId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, contactCompanyData);
            contactCompanyData.Id = id;
            return contactCompanyData;
        }

        internal void Edit(ContactCompany original)
        {
            string sql = @"
            UPDATE contactCompanies
            SET
            contactId = @ContactId,
            companyId = @CompanyId
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM contactCompanies WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
