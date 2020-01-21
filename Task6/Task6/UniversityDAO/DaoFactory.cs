using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDAO
{
    public abstract class DaoFactory
    {
        public abstract GroupDao GetGroupDao();
    }
}
