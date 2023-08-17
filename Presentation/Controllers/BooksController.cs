﻿using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {

            var books = _manager.BookService.GetAllBooks(false);
            return Ok(books);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {

            var book = _manager.BookService.GetOneBookById(id, false);
            

            return Ok(book);


        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {

            if (book is null)
                return BadRequest();
            _manager.BookService.CreateOneBookById(book);

            return StatusCode(201, book);


        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {

            if (bookDto is null)
                return BadRequest();

            _manager.BookService.UpdateOneBookById(id, bookDto, false);
            return NoContent();



        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAOneBooks([FromRoute(Name = "id")] int id)
        {


            _manager.BookService.DeleteOneBookById(id, false);

            return NoContent();

        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {

            var entity = _manager
                .BookService
                .GetOneBookById(id, true);

            

            bookPatch.ApplyTo(entity);
            _manager.BookService.UpdateOneBookById(id,
                new BookDtoForUpdate(entity.Id,entity.Title,entity.Price),
                true);

            return NoContent();

        }
    }
}
