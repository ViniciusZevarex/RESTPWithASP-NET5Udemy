using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BookRepository : IBookRepository
    {

        private readonly MySQLContext _dbContext;

        public BookRepository(MySQLContext mySQLDbContext)
        {
            _dbContext = mySQLDbContext;
        }


        public Book Create(Book book)
        {
            try
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }

            return book;
        }

        public void Delete(long id)
        {
            var result = _dbContext.Books.SingleOrDefault(p => p.Id == id);

            if (result != null)
            {
                try
                {
                    _dbContext.Books.Remove(result);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dbContext.Books.Any(p => p.Id == id);
        }

        public List<Book> FindAll()
        {
            var books = _dbContext.Books.ToList();
            return books;
        }

        public Book FindById(long id)
        {
            return _dbContext.Books.SingleOrDefault(p => p.Id == id);
        }

        public Book Update(Book book)
        {
            if (Exists(book.Id)) return null;


            var result = _dbContext.Persons.SingleOrDefault(p => p.Id == book.Id);

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

            return book;
        }
    }
}
