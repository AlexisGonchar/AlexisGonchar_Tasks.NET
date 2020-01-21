using UniversityORM;

namespace UniversityDAO
{
    public class SubjectDao : Dao<Subject>
    {
        public SubjectDao(string connString) : base(connString)
        {
        }
    }
}
