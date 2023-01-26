using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class ServiceAttemptsRepository
    {

        private readonly MySqlConnection _db;

        public ServiceAttemptsRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<ServiceAttempt> GetAll()
        {
            string sql = @"
            SELECT *
            FROM serviceAttempts
            ";
            return _db.Query<ServiceAttempt>(sql).ToList();
        }

        internal ServiceAttempt Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM serviceAttempts
            WHERE id = @id
            ";
            return _db.Query<ServiceAttempt>(sql, new { id }).FirstOrDefault();
        }

        internal ServiceAttempt Create(ServiceAttempt serviceAttemptData)
        {
            string sql = @"
            INSERT INTO serviceAttempts
            (peId, attemptDateTime, comment, addrId)
            VALUES
            (@PeId, @AttemptDateTime, @Comment, @AddrId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, serviceAttemptData);
            serviceAttemptData.Id = id;
            return serviceAttemptData;
        }

        internal void Edit(ServiceAttempt original)
        {
            string sql = @"
            UPDATE serviceAttempts
            SET
            peId = @PeId,
            attemptDateTime = @AttemptDateTime,
            comment = @Comment,
            addrId = @AddrId
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM serviceAttempts WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
