using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Core.Entities;
using University.Services.Interfaces;

namespace University.Web.Pages.Subjects
{
    public class DeleteModel : PageModel
    {
        private readonly ISubjectService _subjectService;

        public DeleteModel(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                await _subjectService.Delete(id);
                TempData["SuccessMessage"] = "Materia eliminada exitosamente!";
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