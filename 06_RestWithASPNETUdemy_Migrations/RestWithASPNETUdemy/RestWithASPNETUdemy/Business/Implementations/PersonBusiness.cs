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


        private readonly IPersonRepository _personRepository;

        public PersonBusiness(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
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
