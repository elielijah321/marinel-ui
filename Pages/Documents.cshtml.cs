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
using Marinel_ui.Models;

namespace Marinel_ui.Pages
{
    public class DocumentsPageModel : PageModel
    {
        private readonly ILogger<DocumentsPageModel> _logger;
        private readonly ISchoolRepository _schoolRepository;

        private readonly IAZContainerService _aZContainerService;


        public List<DocumentModel> Documents { get; set; }

        public DocumentsPageModel(ISchoolRepository schoolRepo, IAZContainerService aZContainerService,  ILogger<DocumentsPageModel> logger)
        {
            _schoolRepository = schoolRepo;
            _aZContainerService = aZContainerService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await GetPageData();

            return Page();
        }

        public async Task OnPost(IFormFile file)
        {
            var formType = Request.Form["form-type"].ToString();
            await GetPageData();

            switch (formType)
            {
                case "document":
                    AddDocument(file);
                    break;
                default:
                    break;
            }


            await GetPageData();
        }

        private async Task GetPageData()
        {
            Documents =  _aZContainerService.GetFiles();
        }


        private async void AddDocument(IFormFile file)
        {
            var d_Name = Request.Form["document-name"].ToString();
            var d_Type = Request.Form["document-type"].ToString();

            _aZContainerService.AddFile(file, d_Name, d_Type);
        }

        public JsonResult OnGetDeleteDocumentByName(string documentName)
        {
            _aZContainerService.DeleteDocument(documentName);

            return new JsonResult("Ok");
        }
    }
}
