using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class AffidavitTypesRepository
    {

        private readonly MySqlConnection _db;

        public AffidavitTypesRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<AffidavitType> GetAll()
        {
            string sql = @"
            SELECT *
            FROM affidavitTypes
            ";
            return _db.Query<AffidavitType>(sql).ToList();
        }

        internal AffidavitType Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM affidavitTypes
            WHERE id = @id
            ";
            return _db.Query<AffidavitType>(sql, new { id }).FirstOrDefault();
        }

        internal AffidavitType Create(AffidavitType affidavitTypeData)
        {
            string sql = @"
            INSERT INTO affidavitTypes
            (position, name)
            VALUES
            (@Position, @Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, affidavitTypeData);
            affidavitTypeData.Id = id;
            return affidavitTypeData;
        }

        internal void Edit(AffidavitType original)
        {
            string sql = @"
            UPDATE affidavitTypes
            SET
            position = @Position,
            name = @Name
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM affidavitTypes WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
