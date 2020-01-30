using System.Data.Linq.Mapping;

namespace UniversityORM
{
    /// <summary>
    /// Group class
    /// </summary>
    [Table (Name = "Groups")]
    public class Group : IEntry
    {
        /// <summary>
        /// Group identification number.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        /// <summary>
        /// Group name.
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }
    }
}
