using ShinovaIrinaKt_31_22.Dto;
using ShinovaIrinaKt_31_22.Models;

namespace ShinovaIrinaKt_31_22.Services
{
    public interface SubjectService
    {
        Task<PageResponseDto<Subject>> GetAllSubjects(PageRequestDto pageRequest);
        Task<Subject?> GetSubjectById(int id);
        Task<Subject> CreateSubject(Subject subject);
        Task<Subject> UpdateSubject(Subject subject);
        Task<bool> DeleteSubject(int id);
    }
}
