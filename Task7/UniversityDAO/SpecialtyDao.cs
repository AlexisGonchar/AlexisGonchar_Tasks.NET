using UniversityORM;

namespace UniversityDAO
{
    public class SpecialtyDao : Dao<Specialty>
    {
        public SpecialtyDao(string connString) : base(connString)
        {
        }
    }
}
