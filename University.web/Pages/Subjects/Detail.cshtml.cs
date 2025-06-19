using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Core.Entities;
using University.Services.Interfaces;

namespace University.Web.Pages.Subjects
{
    public class DetailsModel : PageModel
    {
        private readonly ISubjectService _subjectService;

        public DetailsModel(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public Subject Subject { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subject = await _subjectService.GetById(id);
            if (Subject == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}