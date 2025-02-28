using ShinovaIrinaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using ShinovaIrinaKt_31_22.Database;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using ShinovaIrinaKt_31_22.Dto;

namespace ShinovaIrinaKt_31_22.Services
{
    public class TeacherServiceImpl : TeacherService
    {
        private readonly UniversityDbContext _context;

        public TeacherServiceImpl(UniversityDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetTeachers(TeacherFilterDto filter)
        {
            var predicate = PredicateBuilder.New<Teacher>(true);

            if (filter.DepartmentId.HasValue)
            {
                predicate = predicate.And(t => t.DepartmentId == filter.DepartmentId.Value);
            }

            if (filter.DegreeId.HasValue)
            {
                predicate = predicate.And(t => t.DegreeId == filter.DegreeId.Value);
            }

            if (filter.PositionId.HasValue)
            {
                predicate = predicate.And(t => t.PositionId == filter.PositionId.Value);
            }

  

            return await _context.Teachers
                .Include(t => t.Degree)
                .Include(t => t.Position)
                .Include(t => t.Department)
                .Where(predicate)
                .ToListAsync();
        }
    }
}
