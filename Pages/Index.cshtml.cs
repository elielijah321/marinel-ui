using Marinel_ui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Marinel_ui.Data;
using Marinel_ui.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marinel_ui.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISchoolRepository _schoolRepository;

        public List<Student> Students { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ISchoolRepository schoolRepo)
        {
            _logger = logger;
            _schoolRepository = schoolRepo;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Students = _schoolRepository.GetAllStudents().ToList();
            return Page();
        }
    }
}
