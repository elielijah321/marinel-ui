using Azure.Identity;
using Marinel_ui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Marinel_ui.Data;
using Marinel_ui.Data.Entities;
using Marinel_ui.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marinel_ui.Pages
{
    public class LibraryPageModel : PageModel
    {
        private readonly ILogger<LibraryPageModel> _logger;
        private readonly ISchoolRepository _schoolRepository;

        public List<LibraryBook> LibraryBooks { get; set; }

        public LibraryPageModel(ISchoolRepository schoolRepo, ILogger<LibraryPageModel> logger)
        {
            _schoolRepository = schoolRepo;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await GetPageData();

            return Page();
        }

        public async Task OnPost()
        {
            var formType = Request.Form["form-type"].ToString();
            await GetPageData();

            switch (formType)
            {
                case "library-book":
                    AddLibraryBook();
                    break;
                case "edit-library-book":
                    UpdateLibraryBook();
                    break;
                default:
                    break;
            }

            
            await GetPageData();
        }

        private void AddLibraryBook()
        {
            var b_Title = Request.Form["library-book-title"].ToString();
            var b_Author = Request.Form["library-book-author"].ToString();
            var b_Quantity = Request.Form["library-book-quantity"].ToString();

            var lb = new LibraryBook();
            lb.Title = b_Title;
            lb.Author = b_Author;
            lb.Quantity = Int32.Parse(b_Quantity);

            _schoolRepository.AddLibraryBook(lb);
        }

        private void UpdateLibraryBook()
        {
            var formIDString = Request.Form[$"form-id"].ToString();

            var b_Title = Request.Form[$"library-book-title-{formIDString}"].ToString();
            var b_Author = Request.Form[$"library-book-author-{formIDString}"].ToString();
            var b_Quantity = Request.Form[$"library-book-quantity-{formIDString}"].ToString();

            var lb = new LibraryBook();
            lb.Id = Int32.Parse(formIDString);
            lb.Title = b_Title;
            lb.Author = b_Author;
            lb.Quantity = Int32.Parse(b_Quantity);

            _schoolRepository.UpdateLibraryBook(lb);
        }

        private async Task GetPageData()
        {
            LibraryBooks = _schoolRepository.GetAllLibraryBook().ToList();
        }
    }
}
