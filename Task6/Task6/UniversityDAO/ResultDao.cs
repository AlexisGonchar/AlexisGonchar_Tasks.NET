using UniversityORM;

namespace UniversityDAO
{
    public class ResultDao : Dao<Result>
    {
        public ResultDao(string connString) : base(connString)
        {
        }
    }
}
