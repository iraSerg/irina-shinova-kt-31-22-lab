namespace ShinovaIrinaKt_31_22.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
