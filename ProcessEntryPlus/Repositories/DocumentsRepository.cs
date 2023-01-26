using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class DocumentsRepository
    {

        private readonly MySqlConnection _db;

        public DocumentsRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<Document> GetAll()
        {
            string sql = @"
            SELECT *
            FROM documents
            ";
            return _db.Query<Document>(sql).ToList();
        }

        internal Document Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM documents
            WHERE id = @id
            ";
            return _db.Query<Document>(sql, new { id }).FirstOrDefault();
        }

        internal Document Create(Document documentData)
        {
            string sql = @"
            INSERT INTO documents
            (position, name)
            VALUES
            (@Position, @Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, documentData);
            documentData.Id = id;
            return documentData;
        }

        internal void Edit(Document original)
        {
            string sql = @"
            UPDATE documents
            SET
            position = @Position,
            name = @Name
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM documents WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
