﻿
using System.Linq.Expressions;
using University.Core.Entities;

namespace University.Infraestructure.Interfaces;
public interface IStudentSubjectRepository
{
    Task<StudentSubject> Get(int studentId, int subjectId);
    Task<bool> Exists(int studentId, int subjectId);
    Task Add(StudentSubject enrollment);
    Task Delete(StudentSubject enrollment);
    Task<IEnumerable<Subject>> GetSubjectsByStudent(int studentId, Expression<Func<Subject, bool>> predicate = null);
    Task<IEnumerable<Subject>> GetAvailableSubjectsForStudent(int studentId);
    Task<int> CountHighCreditSubjects(int studentId);
}