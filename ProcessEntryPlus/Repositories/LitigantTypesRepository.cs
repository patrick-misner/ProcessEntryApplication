using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class LitigantTypesRepository
    {

        private readonly MySqlConnection _db;

        public LitigantTypesRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<LitigantType> GetAll()
        {
            string sql = @"
            SELECT *
            FROM litigantTypes
            ";
            return _db.Query<LitigantType>(sql).ToList();
        }

        internal LitigantType Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM litigantTypes
            WHERE id = @id
            ";
            return _db.Query<LitigantType>(sql, new { id }).FirstOrDefault();
        }

        internal LitigantType Create(LitigantType litigantTypeData)
        {
            string sql = @"
            INSERT INTO litigantTypes
            (position, name)
            VALUES
            (@Position, @Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, litigantTypeData);
            litigantTypeData.Id = id;
            return litigantTypeData;
        }

        internal void Edit(LitigantType original)
        {
            string sql = @"
            UPDATE litigantTypes
            SET
            position = @Position,
            name = @Name
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM litigantTypes WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
