
using University.Core.Dtos;
using University.Core.Entities;

namespace University.Services.Interfaces;
public interface IStudentSubjectService
{
    Task EnrollStudent(int studentId, int subjectId);
    Task UnenrollStudent(int studentId, int subjectId);
    Task<IEnumerable<SubjectDto>> GetEnrolledSubjects(int studentId);
    Task<IEnumerable<SubjectDto>> GetAvailableSubjects(int studentId);
    Task<EnrollmentSummaryDto> GetEnrollmentSummary(int studentId);
}