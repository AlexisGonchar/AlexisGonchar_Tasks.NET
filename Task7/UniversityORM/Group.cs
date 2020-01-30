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
        [Column(Name = "idSpecialty")]
        public int IdSpecialty { get; set; }

        /// <summary>
        /// Initializes a new instance of the Group class.
        /// </summary>
        public Group() { }

        /// <summary>
        /// Initializes a new instance of the Group class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupName"></param>
        public Group(int id, string groupName, int idSpecialty)
        {
            Id = id;
            Name = groupName;
            IdSpecialty = idSpecialty;
        }

        /// <summary>
        /// Initializes a new instance of the Group class.
        /// </summary>
        /// <param name="groupName"></param>
        public Group(string groupName, int idSpecialty)
        {
            Name = groupName;
            IdSpecialty = idSpecialty;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>Boolean true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Group group = obj as Group;
            if (group == null)
                return false;
            return Name.Equals(group.Name) && IdSpecialty.Equals(group.IdSpecialty);
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode() * 5 + IdSpecialty.GetHashCode();
        }
    }
}
