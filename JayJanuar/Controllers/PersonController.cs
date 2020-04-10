using JayJanuar.Core.Mappers;
using JayJanuar.Core.Services;
using JayJanuar.Core.Unity;
using JayJanuar.Core.ViewModels;
using JayJanuar.Data.UOW;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Unity.Resolution;

namespace JayJanuar.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly IUnitOfWork uow;
        private readonly IDisplayPersonMapper dpm;
        public PersonController()
        {
            uow = UnityConfiguration.Resolve<IUnitOfWork>();
            personService = UnityConfiguration.Resolve<IPersonService>(new ResolverOverride[]
            {
                new ParameterOverride("uow", uow)
            });
        }
        [HttpGet]
        [ActionName("GetPersons")]
        public List<DisplayPersonVm> GetPersons(string type)
        {
            return this.personService.GetAllPersons(type);


        }
    }
}
