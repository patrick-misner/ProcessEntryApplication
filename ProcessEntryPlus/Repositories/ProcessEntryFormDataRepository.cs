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

    internal List<ProcessEntryFormData> GetCourts()
    {
      string sql = @"
            SELECT
            'courts' AS Field,
            c.id,
            c.name
            FROM courts c;
            ";
      return _db.Query<ProcessEntryFormData>(sql).ToList();
    }
    internal List<ProcessEntryFormData> GetLitigantTypes()
    {
      string sql = @"
            SELECT
            'litigantTypes' AS Field,
            l.id,
            l.name
            FROM litigantTypes l
            ";
      return _db.Query<ProcessEntryFormData>(sql).ToList();
    }
  }
}
