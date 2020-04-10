using JayJanuar.Model;
using JayJanuar.Repo.Repository;
using System;

namespace JayJanuar.Data.UOW
{
    public class RestUnitOfWork:IUnitOfWork
    {
        public IRepository<Person> PersonRepository
        {
            get
            {
                return personRepository ??
                          (personRepository = new RestRepository<Person>());
            }
        }


        private IRepository<Person> personRepository;

        public RestUnitOfWork()
        { 

        }

    }
}
