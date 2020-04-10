using JayJanuar.Core.ViewModels;
using System.Collections.Generic;

namespace JayJanuar.Core.Services
{
    public interface IPersonService
    {
        List<DisplayPersonVm> GetAllPersons(string type);
    }
}
