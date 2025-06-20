using Moq;
using University.Core.Entities;
using University.Core.Dtos;
using University.Infraestructure.Interfaces;
using University.Services.Services;
using Xunit;

namespace University.Tests.Services;

public class StudentServiceTests
{
    private Mock<IStudentRepository> _mockRepo;
    private StudentService _service;

    public StudentServiceTests()
    {
        _mockRepo = new Mock<IStudentRepository>();
        _service = new StudentService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetById_ReturnsStudent_WhenStudentExists()
    {
        var studentId = 1;
        var expectedStudent = new Student { Id = studentId, Name = "Maicol Arroyave" };
        _mockRepo.Setup(r => r.GetById(studentId)).ReturnsAsync(expectedStudent);

        var result = await _service.GetById(studentId);

        Assert.Equal(expectedStudent, result);
    }

    [Fact]
    public async Task Create_ThrowsException_WhenEmailExists()
    {
        var studentDto = new StudentDto(0, "Maicol Arroyave", "103938", "maicolaroyave10@mail.com");

        _mockRepo.Setup(r => r.GetByEmail(studentDto.Email))
                 .ReturnsAsync(new Student { Id = 999 });

        await Assert.ThrowsAsync<DomainException>(() => _service.Create(studentDto));
    }


    [Fact]
    public async Task Update_UpdatesStudent_WhenValidData()
    {
        var studentDto = new StudentDto(1, "Maicol Arroyavel Alvarez", "10393889", "maicolaroyave10@gmail.com");
        var existingStudent = new Student { Id = 1 };

        _mockRepo.Setup(r => r.GetById(studentDto.Id)).ReturnsAsync(existingStudent);
        _mockRepo.Setup(r => r.GetByEmail(studentDto.Email)).ReturnsAsync((Student)null);
        _mockRepo.Setup(r => r.DocumentExist(studentDto.Document)).ReturnsAsync((Student)null);

        await _service.Update(studentDto);

        _mockRepo.Verify(r => r.Update(It.IsAny<Student>()), Times.Once);
    }

    [Fact]
    public async Task Delete_DeletesStudent_WhenStudentExists()
    {
        var studentId = 1;
        var student = new Student { Id = studentId, StudentSubjects = new List<StudentSubject>() };

        _mockRepo.Setup(r => r.GetByIdWithSubjects(studentId)).ReturnsAsync(student);
        _mockRepo.Setup(r => r.Exists(studentId)).ReturnsAsync(true);

        await _service.Delete(studentId);

        _mockRepo.Verify(r => r.Delete(studentId), Times.Once);
    }

    [Fact]
    public async Task Delete_ThrowsException_WhenStudentDoesNotExist()
    {
        var studentId = 999;
        _mockRepo.Setup(r => r.GetByIdWithSubjects(studentId)).ReturnsAsync((Student)null);

        await Assert.ThrowsAsync<DomainException>(() => _service.Delete(studentId));
    }
}