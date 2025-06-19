using University.Core.Entities;
using University.Core.Utilities;

namespace University.Services.Interfaces;
public interface IStudentService
{
    Task<IEnumerable<Student>> GetAll();
    Task<Student> GetById(int id);
    Task<Student> Create(StudentDto studentDto);
    Task<Student> Update(StudentDto studentDto);
    Task Delete(int id);
    Task<bool> Exists(int id);
    Task<PaginatedList<Student>> GetPaginatedList(int pageNumber, int pageSize, string searchString = null);
}