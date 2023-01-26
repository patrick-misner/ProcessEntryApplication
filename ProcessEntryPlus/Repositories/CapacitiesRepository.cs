using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class CapacitiesRepository
    {

        private readonly MySqlConnection _db;

        public CapacitiesRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<Capacity> GetAll()
        {
            string sql = @"
            SELECT *
            FROM capacities
            ";
            return _db.Query<Capacity>(sql).ToList();
        }

        internal Capacity Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM capacities
            WHERE id = @id
            ";
            return _db.Query<Capacity>(sql, new { id }).FirstOrDefault();
        }

        internal Capacity Create(Capacity capacityData)
        {
            string sql = @"
            INSERT INTO capacities
            (position, name)
            VALUES
            (@Position, @Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, capacityData);
            capacityData.Id = id;
            return capacityData;
        }

        internal void Edit(Capacity original)
        {
            string sql = @"
            UPDATE capacities
            SET
            position = @Position,
            name = @Name
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM capacities WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
