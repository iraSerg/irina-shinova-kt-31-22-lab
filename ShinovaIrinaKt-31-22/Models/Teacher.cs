namespace ShinovaIrinaKt_31_22.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int DegreeId { get; set; } 
        public int PositionId { get; set; } 
        public int DepartmentId { get; set; } 

        public virtual Degree Degree { get; set; }
        public virtual Position Position { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Load> Loads { get; set; } = new List<Load>();
    }
}
