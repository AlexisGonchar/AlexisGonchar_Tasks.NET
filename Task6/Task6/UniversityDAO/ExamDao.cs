using UniversityORM;

namespace UniversityDAO
{
    public class ExamDao : Dao<Exam>
    {
        public ExamDao(string connString) : base(connString)
        {
        }
    }
}
