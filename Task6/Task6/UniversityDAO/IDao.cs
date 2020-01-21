using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDAO
{
    public interface IDao<T>
    {
        bool Create(T obj);

        bool Update(T obj);

        bool DeleteById(int id);

        T Read(int id);

        List<T> ReadAll();
    }
}
