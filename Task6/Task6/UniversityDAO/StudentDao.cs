using UniversityORM;

namespace UniversityDAO
{
    public class StudentDao : Dao<Student>
    {
        public StudentDao(string connString) : base(connString)
        {
        }
    }
}
