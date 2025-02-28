using ShinovaIrinaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using ShinovaIrinaKt_31_22.Database;
using ShinovaIrinaKt_31_22.Dto;

namespace ShinovaIrinaKt_31_22.Services
{
    public class SubjectServiceImpl: SubjectService
    {
        private readonly UniversityDbContext _context;

        public SubjectServiceImpl(UniversityDbContext context)
        {
            _context = context;
        }
        public async Task<PageResponseDto<Subject>> GetAllSubjects(PageRequestDto pagination)
        {
            var totalCount = await _context.Subjects.CountAsync();

            var items = await _context.Subjects
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize);

            return new PageResponseDto<Subject>
            {
                Items = items,
                TotalCount = totalCount,
                PageSize = pagination.PageSize,
                PageNumber = pagination.PageNumber,
                TotalPages = totalPages
            };
        }
            public async Task<Subject?> GetSubjectById(int id)
        {
            return await _context.Subjects.Include(s => s.Teacher).FirstOrDefaultAsync(s => s.SubjectId == id);
        }

        public async Task<Subject> CreateSubject(Subject subject)
        {
            var newSubject = new Subject
            {
                Name = subject.Name,
                TeacherId = subject.TeacherId
            };

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return newSubject;
        }

        public async Task<Subject> UpdateSubject(Subject subject)
        {
            var updateSubject = await _context.Subjects.FindAsync(subject.SubjectId);

            if (subject == null)
            {
                return null; 
            }

            updateSubject.Name = subject.Name;
            updateSubject.TeacherId = subject.TeacherId;

            _context.Subjects.Update(updateSubject);
            await _context.SaveChangesAsync();

            return updateSubject;
        }

        public async Task<bool> DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return false; 
            }

                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
                return true;
           

        }
    }
}
