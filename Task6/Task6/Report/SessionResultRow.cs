using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    /// <summary>
    /// Class SessionResultRow.
    /// </summary>
    public class SessionResultRow
    {
        /// <summary>
        /// Group name.
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Min mark.
        /// </summary>
        public double MinMark { get; set; }
        /// <summary>
        /// Max mark.
        /// </summary>
        public double MaxMark { get; set; }
        /// <summary>
        /// Average mark.
        /// </summary>
        public double AverageMark { get; set; }
    }
}
