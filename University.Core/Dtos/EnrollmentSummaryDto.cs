
namespace University.Core.Dtos;
public class EnrollmentSummaryDto
{
    public int TotalSubjects { get; set; }
    public int HighCreditSubjects { get; set; }
    public bool CanEnrollMoreHighCredit { get; set; }
}