using MySqlConnector;
using ProcessEntryPlus.Models;
using Dapper;

namespace ProcessEntryPlus.Repositories
{
  public class ProcessEntryFormDataRepository
  {
    private readonly MySqlConnection _db;

    public ProcessEntryFormDataRepository(MySqlConnection db)
    {
      _db = db;
    }

    internal List<ProcessEntryFormField> GetCourts()
    {
      string sql = @"
            SELECT
            c.id,
            c.name
            FROM courts c;
            ";
      return _db.Query<ProcessEntryFormField>(sql).ToList();
    }
    internal List<ProcessEntryFormField> GetLitigantTypes()
    {
      string sql = @"
            SELECT
            l.id,
            l.name
            FROM litigantTypes l
            ";
      return _db.Query<ProcessEntryFormField>(sql).ToList();
    }
  }
}
