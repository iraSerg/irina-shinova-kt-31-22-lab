namespace ShinovaIrinaKt_31_22.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public int HeadId { get; set; } 
        public virtual Teacher Head { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }= new List<Teacher>();
    }
}
