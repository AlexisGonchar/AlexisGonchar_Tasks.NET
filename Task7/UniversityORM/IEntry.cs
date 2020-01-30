using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityORM
{
    /// <summary>
    /// Interface for storage id.
    /// </summary>
    public interface IEntry
    {
        /// <summary>
        /// Identification number.
        /// </summary>
        int Id { get; set; }
    }
}
