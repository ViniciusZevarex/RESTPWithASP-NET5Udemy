using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {


        private readonly IRepository<Person> _personRepository;

        public PersonBusiness(IRepository<Person> repository)
        {
            _personRepository = repository;
        }




        public Person Create(Person person)
        {
            var personResult = _personRepository.Create(person);
            return personResult;
        }




        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }



        public List<Person> FindAll()
        {
            var persons = _personRepository.FindAll();
            return persons;
        }




        public Person FindById(long id)
        {
            var person = _personRepository.FindById(id);
            return person;
        }




        public Person Update(Person person)
        {
            var personResult = _personRepository.Update(person);
            return personResult;
        }
    }
}
