using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        List<BookModel> GetAll();
        List<BookModel> GetByName(string name);
        BookModel GetById(Guid bookId);
        Guid Insert(BookModel book);
        Guid Update(BookModel book);
        long Delete(Guid bookId);
    }
}
