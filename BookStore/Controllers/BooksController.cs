using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _bookRepository;

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        //Retrieve all the books
        public ResponseMessage ListBooks()
        {
            var response = new ResponseMessage();
            var data = _bookRepository.GetAll();
            response.Data = data;
            if(data.Count==0)
            {
                response.Message="No books available.";
            }
            return response;

        }
        [HttpGet]
        //Retrieve books by title
        public ResponseMessage SearchByName(string name)
        {
            var response = new ResponseMessage();
            var data = _bookRepository.GetByName(name);
            response.Data = data;
            if(data==null)
            {
                response.Message = $"No book with name:{name} found.";
            }
            return response;
        }
        [HttpGet]
        //Retrieve book by unique identifier
        public ResponseMessage Get(Guid id)
        {
            var response = new ResponseMessage();
            var data = _bookRepository.GetById(id);
            response.Data = data;
            if(data == null)
            {
                response.Message = $"No book with id:{id} found.";
            }
            return response;
        }
        [HttpPost]
        //Delete book by Id.
        public ResponseMessage DeleteBook(Guid id)
        {
            var response = new ResponseMessage();
            var data = _bookRepository.Delete(id);
            response.Data = data;
            if(data == 0)
            {
                response.Message = $"No books deleted.";
            }
            else
            {
                response.Message = $"Number of books deleted: {data}";
            }
            return response;

        }
        [HttpPost]
        //Add new book
        public ResponseMessage AddBook(BookModel book)
        {
            var response = new ResponseMessage();
            var data = _bookRepository.Insert(book);
            response.Data = data;
            if(data==Guid.Empty)
            {
                response.Message = $"Book with Id: {book.Id} already exists.";
            }
            return response;
        }
        [HttpPost]
        //Update an existing book
        public ResponseMessage UpdateBook(BookModel book)
        {
            var response = new ResponseMessage();
            var data = _bookRepository.Update(book);
            response.Data = data;
            if(data == Guid.Empty)
            {
                response.Message = "Unable to update as no matching book found.";
            }
            return response;
        }
    }
}
