using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        protected static List<BookModel> _books = new List<BookModel>();
        public BookRepository()
        {
            if(_books == null || _books.Count == 0)
                SeedBooks();
        }

        public Guid Insert(BookModel book)
        {
            if(book.Id == Guid.Empty)
            {
                book.Id = Guid.NewGuid();
            }
            if(_books == null)
            {
                _books = new List<BookModel>();
            }
            var existingBook = _books.Where(b => b.Id.Equals(book.Id)).FirstOrDefault();
            if(existingBook != null)
            {
                return Guid.Empty;
            }
            _books.Add(book);
            return book.Id;
        }

        public long Delete(Guid bookId)
        {
            long deletedBooksCount = 0;
            if(_books != null && _books.Count > 0)
            {
                var existingBook = _books.Where(b => b.Id.Equals(bookId)).FirstOrDefault();
                if(existingBook != null)
                {
                    _books.Remove(existingBook);
                    deletedBooksCount = 1;
                }
            }
            return deletedBooksCount;
        }

        public List<BookModel> GetAll()
        {
            return _books;
        }

        public BookModel GetById(Guid bookId)
        {
            if(_books != null)
            {
                var book = _books.Where(b => b.Id.Equals(bookId)).FirstOrDefault();
                return book;
            }
            return null;
        }

        public List<BookModel> GetByName(string name)
        {
            if(_books != null)
            {
                var matchingBooks = _books.Where(b => !string.IsNullOrWhiteSpace(b.Title) && b.Title.Equals(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
                return matchingBooks;
            }
            return null;
        }

        public Guid Update(BookModel book)
        {
            if(_books != null && _books.Count > 0)
            {
                var existingBook = _books.Where(b => book.Id != Guid.Empty && b.Id.Equals(book.Id)).FirstOrDefault();
                if(existingBook != null)
                {
                    _books.Remove(existingBook);
                    _books.Add(book);
                    return book.Id;
                }
            }
            return Guid.Empty;
        }

        private void SeedBooks()
        {
            _books.Add(new BookModel
            {
                Id = Guid.Parse("{DCCBEE5F-8F69-436C-8C0D-BB92F8609AAC}"),
                Title = "How I met Han",
                Author = "Chewbacca",
                Description = "Memoirs of the great adventurer Chewbacca and how he met Han Solo.",
                Price = 349,
                CoverImage = "https://i.pinimg.com/736x/21/87/b1/2187b1a818017f9b4c777cbf30d3d00d.jpg"
            });
            _books.Add(new BookModel
            {
                Id = Guid.Parse("{E36811A5-90ED-42F1-9D8F-2F0E4D0ED9B6}"),
                Title = "History of Kashyyyk",
                Author = "Lohgarra",
                Description = "An Informative text describing the history of Kashyyyk from when, it was a member of the Galactic Republic and after the Clone Wars endured enslavement under the Galactic Empire.",
                Price = 120,
                CoverImage = "https://i.pinimg.com/originals/37/8c/01/378c01c9dbb0d10626b1e63e87a93432.jpg"
            });
        }
    }
}
