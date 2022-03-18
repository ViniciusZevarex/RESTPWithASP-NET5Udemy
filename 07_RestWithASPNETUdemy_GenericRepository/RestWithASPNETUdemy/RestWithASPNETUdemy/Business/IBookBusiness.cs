using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindById(long id);
        Book Update(Book book);
        List<Book> FindAll();
        void Delete(long id);
    }
}
