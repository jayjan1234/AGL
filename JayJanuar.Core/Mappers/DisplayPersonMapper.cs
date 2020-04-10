using JayJanuar.Core.ViewModels;
using JayJanuar.Model;
using System.Collections.Generic;
using System.Linq;

namespace JayJanuar.Core.Mappers
{
    public class DisplayPersonMapper: IDisplayPersonMapper
    {
        public DisplayPersonMapper()
        {
        }
        public List<DisplayPersonVm> ConvertPersonsToDisplayPersonVms(List<Person> persons)
        {
            List<DisplayPersonVm> dpvs = new List<DisplayPersonVm>();
            List<string> genders = persons.Select(x => x.gender).Distinct().ToList();
            persons = persons.OrderBy(x => x.name).ToList();
            foreach (var gender in genders)
            {

                DisplayPersonVm dpv = new DisplayPersonVm();
                dpv.gender = gender;
                dpv.names = new List<string>();
                foreach (var person in persons.Where(x => x.gender == gender))
                {
                    dpv.names.Add(person.name);
                }
                dpvs.Add(dpv);
            }
            return dpvs;
        }

    }
}
