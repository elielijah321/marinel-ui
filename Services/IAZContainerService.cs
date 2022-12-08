using System;
using System.Threading.Tasks;

namespace Marinel_ui.Services
{
    public interface IAZContainerService
    {
        void AddFile(IFormFile file, string prefferedName);
    }
}

