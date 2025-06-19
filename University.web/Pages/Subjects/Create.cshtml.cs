using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Core.Entities;
using University.Services.Interfaces;

namespace University.Web.Pages.Subjects
{
    public class CreateModel : PageModel
    {
        private readonly ISubjectService _subjectService;

        public CreateModel(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [BindProperty]
        public Subject Subject { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _subjectService.Create(Subject);
                TempData["SuccessMessage"] = "Materia creada exitosamente!";
                return RedirectToPage("./Index");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Page();
            }
        }
    }
}