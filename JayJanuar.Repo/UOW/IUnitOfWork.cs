
using JayJanuar.Model;
using JayJanuar.Repo.Repository;
using System;

namespace JayJanuar.Data.UOW
{
    public interface IUnitOfWork
    {
        //if there's any update or insert, there should be a commit method here. since this excercise is only executing get, there's no commit method required.
        IRepository<Person> PersonRepository { get; }
     
    }
}
