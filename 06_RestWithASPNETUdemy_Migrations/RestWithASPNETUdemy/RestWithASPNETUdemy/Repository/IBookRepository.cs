using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository
{
    public interface IBookRepository
    {

        Book Create(Book book);
        Book FindById(long id);
        Book Update(Book book);
        List<Book> FindAll();
        void Delete(long id);
        bool Exists(long id);
    }
}
