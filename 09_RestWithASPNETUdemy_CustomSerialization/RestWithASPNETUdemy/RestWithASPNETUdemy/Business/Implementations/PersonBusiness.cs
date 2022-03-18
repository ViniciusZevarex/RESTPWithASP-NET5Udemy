using RestWithASPNETUdemy.Data.Converter.Implementation;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {


        private readonly IRepository<Person> _personRepository;

        private readonly PersonConverter _converter;

        public PersonBusiness(IRepository<Person> repository)
        {
            _personRepository = repository;
            _converter = new PersonConverter();
        }




        public PersonVO Create(PersonVO person)
        {
            var personResult = _personRepository.Create(_converter.Parse(person));
            return _converter.Parse(personResult);
        }




        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }



        public List<PersonVO> FindAll()
        {
            var persons = _personRepository.FindAll();
            return _converter.Parse(persons);
        }




        public PersonVO FindById(long id)
        {
            var person = _personRepository.FindById(id);
            return _converter.Parse(person);
        }




        public PersonVO Update(PersonVO person)
        {
            var personResult = _personRepository.Update(_converter.Parse(person));
            return _converter.Parse(personResult);
        }
    }
}
