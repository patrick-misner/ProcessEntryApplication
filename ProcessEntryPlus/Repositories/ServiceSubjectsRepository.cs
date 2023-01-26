using Dapper;
using MySqlConnector;
using ProcessEntryPlus.Models;


namespace ProcessEntryPlus.Repositories
{
    public class ServiceSubjectsRepository
    {

        private readonly MySqlConnection _db;

        public ServiceSubjectsRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<ServiceSubject> GetAll()
        {
            string sql = @"
            SELECT *
            FROM serviceSubjects
            ";
            return _db.Query<ServiceSubject>(sql).ToList();
        }

        internal ServiceSubject Get(int id) 
        {
            string sql = @"
            SELECT *
            FROM serviceSubjects
            WHERE id = @id
            ";
            return _db.Query<ServiceSubject>(sql, new { id }).FirstOrDefault();
        }

        internal ServiceSubject Create(ServiceSubject serviceSubjectData)
        {
            string sql = @"
            INSERT INTO serviceSubjects
            (name, dob, picture, phone, mobile, fax, email, website, notes, race, sex, age, height, weight, hair, glasses, driversLicense, militaryStatus)
            VALUES
            (@Name, @Dob, @Picture, @Phone, @Mobile, @Fax, @Email, @Website, @Notes, @Race, @Sex, @Age, @Height, @Weight, @Hair, @Glasses, @DriversLicense, @MilitaryStatus);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, serviceSubjectData);
            serviceSubjectData.Id = id;
            return serviceSubjectData;
        }

        internal void Edit(ServiceSubject original)
        {
            string sql = @"
            UPDATE serviceSubjects
            SET
            name = @Name,
            dob = @Dob,
            picture = @Picture,
            phone = @Phone,
            mobile = @Mobile,
            fax = @Fax,
            email = @Email,
            website = @Website,
            notes = @Notes,
            race = @Race,
            sex = @Sex,
            age = @Age,
            height = @Height,
            weight = @Weight,
            hair = @Hair,
            glasses = @Glasses,
            driversLicense = @DriversLicense,
            militaryStatus = @MilitaryStatus
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM serviceSubjects WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });   
        }
    }
}
