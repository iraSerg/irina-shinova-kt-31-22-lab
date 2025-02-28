namespace ShinovaIrinaKt_31_22.Models
{
    public class Degree
    {
        public int DegreeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
