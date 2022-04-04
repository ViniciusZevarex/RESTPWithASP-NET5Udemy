using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepository(MySQLContext context) : base(context) { }

        public Person Disable(long id)
        {
            if (!_dbContext.Persons.Any(x => x.Id == id)) return null;
            var user = _dbContext.Persons.SingleOrDefault(x => x.Id == id);

            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _dbContext.Entry(user).CurrentValues.SetValues(user);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return user;
        }

        public List<Person> FindByName(string firstName, string secondName)
        {

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(secondName))
            {

                return _dbContext.Persons.Where(
                            p => p.FirstName.Contains(firstName) &&
                            p.LastName.Contains(firstName)
                       ).ToList();
            }else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(secondName))
            {
                return _dbContext.Persons.Where(
                        p => p.FirstName.Contains(firstName)
                   ).ToList();
            }
            else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(secondName))
            {
                return _dbContext.Persons.Where( p =>
                        p.LastName.Contains(firstName)
                   ).ToList();
            }
            else
            {
                return null;
            }

        }


    }
}
