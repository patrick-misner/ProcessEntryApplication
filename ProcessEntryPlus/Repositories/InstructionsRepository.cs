using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class InstructionsRepository
    {

        private readonly MySqlConnection _db;

        public InstructionsRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<Instruction> GetAll()
        {
            string sql = @"
            SELECT *
            FROM instructions
            ";
            return _db.Query<Instruction>(sql).ToList();
        }

        internal Instruction Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM instructions
            WHERE id = @id
            ";
            return _db.Query<Instruction>(sql, new { id }).FirstOrDefault();
        }

        internal Instruction Create(Instruction instructionData)
        {
            string sql = @"
            INSERT INTO instructions
            (position, name)
            VALUES
            (@Position, @Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, instructionData);
            instructionData.Id = id;
            return instructionData;
        }

        internal void Edit(Instruction original)
        {
            string sql = @"
            UPDATE instructions
            SET
            position = @Position,
            name = @Name
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM instructions WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
