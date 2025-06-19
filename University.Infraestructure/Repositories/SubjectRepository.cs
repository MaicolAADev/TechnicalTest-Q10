using Microsoft.EntityFrameworkCore;
using University.Core.Entities;
using University.Infraestructure.Data;
using University.Infraestructure.Interfaces;

namespace University.Infraestructure.Repositories;

public class SubjectRepository : ISubjectRepository
{
    private readonly ProjectDbContext _context;

    public SubjectRepository(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Subject>> GetAll()
    {
        return await _context.Subjects.ToListAsync();
    }

    public IQueryable<Subject> GetAllQueryable()
    {
        return _context.Subjects.AsQueryable();
    }

    public async Task<Subject> GetById(int id)
    {
        return await _context.Subjects.FindAsync(id);
    }

    public async Task<Subject> GetByCode(string code)
    {
        return await _context.Subjects
            .FirstOrDefaultAsync(c => c.Code == code);
    }

    public async Task<Subject> Add(Subject subject)
    {
        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();
        return subject;
    }

    public async Task<Subject> Update(Subject subject)
    {
        _context.Entry(subject).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return subject;
    }

    public async Task Delete(int id)
    {
        var course = await GetById(id);
        if (course != null)
        {
            _context.Subjects.Remove(course);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Subjects.AnyAsync(e => e.Id == id);
    }

    public async Task<Subject> GetByIdWithEnrollments(int id)
    {
        return await _context.Subjects
            .Include(s => s.StudentSubjects)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}