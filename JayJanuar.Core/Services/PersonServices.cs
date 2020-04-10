
using JayJanuar.Core.Mappers;
using JayJanuar.Core.ViewModels;
using JayJanuar.Data.UOW;
using JayJanuar.Model;
using System.Collections.Generic;
using System.Linq;

namespace JayJanuar.Core.Services
{
    public class PersonServices : BaseService, IPersonService
    {
        public PersonServices(IUnitOfWork uow) : base(uow){ }
        public List<DisplayPersonVm> GetAllPersons(string type)
        {
            List<DisplayPersonVm> pvs = new List<DisplayPersonVm>();
            DisplayPersonMapper pm = new DisplayPersonMapper();
            List<Person> persons = this.unitOfWork.PersonRepository.GetAll().ToList();
           persons = (from p in persons
                       where p.pets!=null &&  p.pets.Where(x => string.IsNullOrEmpty(type) || x.type.ToLowerInvariant() == type.ToLowerInvariant()).Count() > 0
                       select p).ToList();
            pvs = pm.ConvertPersonsToDisplayPersonVms(persons);
            return pvs;
        }


    }
}
