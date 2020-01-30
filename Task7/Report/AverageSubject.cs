using System.Collections.Generic;

namespace Report
{
    /// <summary>
    /// AverageSubject class.
    /// </summary>
    public class AverageSubject
    {
        /// <summary>
        /// Subject name.
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// Average marks for all sessions.
        /// </summary>
        public List<double> AverageMarks { get; set; }
    }
}
