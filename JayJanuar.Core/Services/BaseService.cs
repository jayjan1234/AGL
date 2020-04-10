
using JayJanuar.Core.Unity;
using JayJanuar.Data.UOW;
using System;

namespace JayJanuar.Core.Services
{
    public class BaseService
    {

        protected readonly IUnitOfWork unitOfWork;
        public BaseService(IUnitOfWork uow)
        {
            //unitOfWork = UnityConfiguration.Resolve<IUnitOfWork>();
            unitOfWork = uow;
        }

    }
}
