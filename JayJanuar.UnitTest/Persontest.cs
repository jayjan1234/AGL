using JayJanuar.Core.Mappers;
using JayJanuar.Core.Services;
using JayJanuar.Core.ViewModels;
using JayJanuar.Data.UOW;
using JayJanuar.Model;
using JayJanuar.Repo.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Newtonsoft.Json;

namespace JayJanuar.UnitTest
{
    public class PersonTest
    {
        Mock<IRepository<Person>> personRepo;
        Mock<IUnitOfWork> uow;
        List<DisplayPersonVm> dpvs;
        List<DisplayPersonVm> dpvsCat;
        IQueryable<Person> persons;

        public PersonTest()
        {
            persons = new List<Person>()
            {
                new Person()
                {
                    age = 10, gender = "Male", name = "John" , pets = new List<Pet>()
                    {
                        new Pet()
                        {
                            name = "poppy",
                            type = "dog"
                        },
                         new Pet()
                        {
                            name = "Minty",
                            type = "cat"
                        }
                    }
                },
                 new Person()
                {
                    age = 14, gender = "Female", name = "Mandy" , pets = new List<Pet>()
                    {
                        new Pet()
                        {
                            name = "Bingo",
                            type = "dog"
                        }
                    }
                },
                  new Person()
                {
                    age = 12, gender = "Female", name = "Melly" , pets = new List<Pet>()
                    {
                         new Pet()
                        {
                            name = "Minty",
                            type = "cat"
                        }
                    }
                }
            }.AsQueryable();
            dpvs = new List<DisplayPersonVm>()
            {
                 new DisplayPersonVm()
                {
                    gender = "Male",
                    names = new List<string>(){ "John"}
                },
                new DisplayPersonVm()
                {
                    gender = "Female",
                    names = new List<string>(){ "Mandy", "Melly"}
                }

            };
            dpvsCat = new List<DisplayPersonVm>()
            {
                 new DisplayPersonVm()
                {
                    gender = "Male",
                    names = new List<string>(){ "John"}
                },
                new DisplayPersonVm()
                {
                    gender = "Female",
                    names = new List<string>(){ "Melly"}
                }

            };
            personRepo = new Mock<IRepository<Person>>();
            personRepo.Setup(x => x.GetAll()).Returns(persons);
            uow = new Mock<IUnitOfWork>();
            uow.SetupGet(x => x.PersonRepository).Returns(personRepo.Object);

        }
        [Fact]
        public void GetAllCatPersons_ReturnsCorrectResult()
        {
            IPersonService ps = new PersonServices(this.uow.Object);
            string displayCatString = JsonConvert.SerializeObject(ps.GetAllPersons("cat"));
            string dpvsCatString = JsonConvert.SerializeObject(dpvsCat);
            Assert.Equal(displayCatString, dpvsCatString);
        }

        [Fact]
        public void GetAllPersons_ReturnsCorrectResult()
        {
            IPersonService ps = new PersonServices(this.uow.Object);
            string displayCatString = JsonConvert.SerializeObject(ps.GetAllPersons(String.Empty));
            string dpvsString = JsonConvert.SerializeObject(dpvs);
            Assert.Equal(displayCatString, dpvsString);
        }
    }
}
