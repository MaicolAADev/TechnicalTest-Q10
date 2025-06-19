
using System.ComponentModel.DataAnnotations;

namespace University.Core.Dtos;

public class EnrollmentRequestDto
{
    [Required]
    public int StudentId { get; set; }

    [Required]
    public int SubjectId { get; set; }
}