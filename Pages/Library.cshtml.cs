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
using Marinel_ui.Helpers;

namespace Marinel_ui.Pages
{
    public class LibraryPageModel : PageModel
    {
        private readonly ILogger<LibraryPageModel> _logger;
        private readonly ISchoolRepository _schoolRepository;

        public List<LibraryBookRental> LibraryBookRentals { get; set; }
        public List<LibraryBook> LibraryBooks { get; set; }
        public List<Class> Classes { get; set; }

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
                case "library-book-rental":
                    AddLibraryBookRental();
                    break;
                case "edit-library-rental":
                    UpdateLibraryBookRental();
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

        private void AddLibraryBookRental()
        {
            var formIDString = Request.Form[$"form-id"].ToString();
            const long borrowDate = 14;

            var br_StudentID = Request.Form[$"library-book-rental-student-" + formIDString].ToString();
            var br_RentalDate = Request.Form[$"library-book-rental-date-" + formIDString].ToString();

            var parsedRentedDate = DateTimeHelper.ToDayMonthYear(br_RentalDate);
            var expextedReturnDate = parsedRentedDate.AddDays(borrowDate);

            var libraryBookRental = new LibraryBookRental()
            {
                LibraryBookId = Int32.Parse(formIDString),
                StudentId = Int32.Parse(br_StudentID),
                RentedDate = parsedRentedDate,
                ExpextedReturnDate = expextedReturnDate
            };

            _schoolRepository.AddLibraryBookRental(libraryBookRental);
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

        private void UpdateLibraryBookRental()
        {
            var formIDString = Request.Form[$"form-id"].ToString();
            var libraryBookRentalId = Int32.Parse(formIDString);

            var rental_ExpectedReturnDate = Request.Form[$"edit-library-rental-expected-return-date-{formIDString}"].ToString();
            var rental_ReturnDate = Request.Form[$"edit-library-rental-actual-return-date-{formIDString}"].ToString();

            var parsedExpectedReturnDate = DateTimeHelper.ToDayMonthYear(rental_ExpectedReturnDate);
            var parsedReturnDate = string.IsNullOrEmpty(rental_ReturnDate) ? (DateTime?)null : DateTimeHelper.ToDayMonthYear(rental_ReturnDate);

            var libraryRental = _schoolRepository.GetAllLibraryBookRentals().FirstOrDefault(lbr => lbr.Id == libraryBookRentalId);
            libraryRental.ExpextedReturnDate = parsedExpectedReturnDate;
            libraryRental.ActualReturnDate = parsedReturnDate;

            _schoolRepository.UpdateLibraryBookRental(libraryRental);
        }


        private async Task GetPageData()
        {
            LibraryBooks = _schoolRepository.GetAllLibraryBook().ToList();
            LibraryBookRentals = _schoolRepository.GetAllLibraryBookRentals().ToList();
            Classes = _schoolRepository.GetAllClasses().ToList();
        }

        public JsonResult OnGetStudentsByClassId(int classId)
        {
            GetPageData();

            var students = Classes.FirstOrDefault(c => c.Id == classId).Students.Select(s => {
                return new { Id = s.Id, Name = s.Name };
            });


            return new JsonResult(students);
        }
    }
}
