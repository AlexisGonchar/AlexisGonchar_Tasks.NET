﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityORM
{
    /// <summary>
    /// Subject class.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Subject identification number.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Subject name.
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Initializes a new instance of the Subject class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectName"></param>
        public Subject(int id, string subjectName)
        {
            Id = id;
            SubjectName = subjectName;
        }
    }
}
