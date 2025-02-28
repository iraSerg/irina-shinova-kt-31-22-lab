using ShinovaIrinaKt_31_22.Dto;
using ShinovaIrinaKt_31_22.Models;

namespace ShinovaIrinaKt_31_22.Services
{
    public interface TeacherService
    {
        Task<IEnumerable<Teacher>> GetTeachers(TeacherFilterDto filter);
    }
}
