using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDAO
{
    public abstract class Factory
    {
        public abstract GroupDao GetGroupDao();
        public abstract SubjectDao GetSubjectDao();
        public abstract StudentDao GetStudentDao();
        public abstract ExamDao GetExamDao();
        public abstract ResultDao GetResultDao();
        public abstract SpecialtyDao GetSpecialtyDao();
        public abstract ExaminatorDao GetExaminatorDao();
    }
}
