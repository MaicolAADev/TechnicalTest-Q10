using University.Core.Entities;

namespace University.Infraestructure.Interfaces;

public interface ISubjectRepository
{
    Task<IEnumerable<Subject>> GetAll();
    Task<Subject> GetById(int id);
    Task<Subject> GetByCode(string code);
    Task<Subject> Add(Subject subject);
    Task<Subject> Update(Subject subject);
    Task Delete(int id);
    Task<bool> Exists(int id);
    IQueryable<Subject> GetAllQueryable();
}
