namespace ShinovaIrinaKt_31_22.Models
{
    public class Load
    {
        public int LoadId { get; set; }
        public int TeacherId { get; set; }
        public int Hours { get; set; } 

        public virtual Teacher Teacher { get; set; }
    }
}
