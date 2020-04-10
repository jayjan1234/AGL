using JayJanuar.Core.ViewModels;
using JayJanuar.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JayJanuar.Core.Mappers
{
    public interface IDisplayPersonMapper
    {
        List<DisplayPersonVm> ConvertPersonsToDisplayPersonVms(List<Person> persons);
    }
}
