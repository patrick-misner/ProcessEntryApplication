using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class MethodsRepository
    {

        private readonly MySqlConnection _db;

        public MethodsRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<Method> GetAll()
        {
            string sql = @"
            SELECT *
            FROM methods
            ";
            return _db.Query<Method>(sql).ToList();
        }

        internal Method Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM methods
            WHERE id = @id
            ";
            return _db.Query<Method>(sql, new { id }).FirstOrDefault();
        }

        internal Method Create(Method methodData)
        {
            string sql = @"
            INSERT INTO methods
            (position, name)
            VALUES
            (@Position, @Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, methodData);
            methodData.Id = id;
            return methodData;
        }

        internal void Edit(Method original)
        {
            string sql = @"
            UPDATE methods
            SET
            position = @Position,
            name = @Name
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM methods WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
