using UniversityORM;

namespace UniversityDAO
{
    public class ExaminatorDao : Dao<Examinator>
    {
        public ExaminatorDao(string connString) : base(connString)
        {
        }
    }
}
