
using System.ComponentModel.DataAnnotations;
using University.Core.Entities;

namespace University.Core.Dtos;

public class SubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Code { get; set; }
    public int Credits { get; set; }
    public ICollection<StudentSubject> StudentSubjects { get; set; }
}