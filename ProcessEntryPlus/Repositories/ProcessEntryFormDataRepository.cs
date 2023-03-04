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
    internal List<ProcessEntryFormField> GetDocuments()
    {
      string sql = @"
            SELECT
            d.id,
            d.name
            FROM documents d
            ";
      return _db.Query<ProcessEntryFormField>(sql).ToList();
    }
    internal List<ProcessEntryFormField> GetInstructions()
    {
      string sql = @"
            SELECT
            i.id,
            i.name
            FROM instructions i
            ";
      return _db.Query<ProcessEntryFormField>(sql).ToList();
    }
    internal List<ProcessEntryFormField> GetServers()
    {
      string sql = @"
            SELECT
            s.id,
            s.name
            FROM servers s
            ";
      return _db.Query<ProcessEntryFormField>(sql).ToList();
    }
    internal List<ProcessEntryFormField> GetMethods()
    {
      string sql = @"
            SELECT
            m.id,
            m.name
            FROM methods m
            ";
      return _db.Query<ProcessEntryFormField>(sql).ToList();
    }
    internal List<ProcessEntryFormField> GetCapacities()
    {
      string sql = @"
            SELECT
            c.id,
            c.name
            FROM capacities c
            ";
      return _db.Query<ProcessEntryFormField>(sql).ToList();
    }
    internal List<ProcessEntryFormField> GetAffidavitTypes()
    {
      string sql = @"
            SELECT
            a.id,
            a.name
            FROM affidavitTypes a
            ";
      return _db.Query<ProcessEntryFormField>(sql).ToList();
    }
  }
}
