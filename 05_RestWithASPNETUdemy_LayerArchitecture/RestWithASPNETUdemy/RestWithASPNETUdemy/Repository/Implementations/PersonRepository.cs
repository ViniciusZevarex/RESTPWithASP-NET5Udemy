using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepository : IPersonRepository
    {


        private readonly MySQLContext _dbContext;

        public PersonRepository(MySQLContext mySQLDbContext)
        {
            _dbContext = mySQLDbContext;
        }




        public Person Create(Person person)
        {
            try
            {
                _dbContext.Persons.Add(person);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }

            return person;
        }




        public void Delete(long id)
        {
            var result = _dbContext.Persons.SingleOrDefault(p => p.Id == id);

            if (result != null)
            {
                try
                {
                    _dbContext.Persons.Remove(result);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

        }



        public List<Person> FindAll()
        {
            var persons = _dbContext.Persons.ToList();
            return persons;
        }




        public Person FindById(long id)
        {
            return _dbContext.Persons.SingleOrDefault(p => p.Id == id);
        }




        public Person Update(Person person)
        {
            if (Exists(person.Id)) return null;


            var result = _dbContext.Persons.SingleOrDefault(p => p.Id == person.Id);

            if (result != null)
            {
                try
                {
                    _dbContext.Entry(result).CurrentValues.SetValues(result);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return person;
        }




        public bool Exists(long id)
        {
            return _dbContext.Persons.Any(p => p.Id == id);
        }
    }
}
