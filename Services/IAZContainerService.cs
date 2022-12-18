using System;
using System.Threading.Tasks;
using Marinel_ui.Models;

namespace Marinel_ui.Services
{
    public interface IAZContainerService
    {
        void AddFile(IFormFile file, string prefferedName);
        List<DocumentModel> GetFiles();
        void DownloadDocument(string documentName);
        void DeleteDocument(string documentName);
    }
}

