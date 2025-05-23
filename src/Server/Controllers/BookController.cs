﻿using HelpLibrary.DTOs.Books;
using HelpLibrary.DTOs.Library;
using HelpLibrary.DTOs.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Services.Interfaces;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet("/api/books/genres")]
        public async Task<IActionResult> GetGenres()
        {
            var result = await _bookService.GetAllGenresAsync();
            return Ok(result);
        }

        [HttpPost("/api/books")]
        public async Task<IActionResult> AddBook([FromForm] AddBookDTO book)
        {
            if (book == null) return BadRequest("Model is empty");

            try
            {
                var result = await _bookService.AddBookAsync(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/api/books")]
        public async Task<IActionResult> DeleteBook([FromForm] int id)
        {
            if (id < 0) return BadRequest("Model is empty");

            try
            {
                var result = await _bookService.RemoveBookAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/books")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateBook([FromForm] UpdateBookDTO book)
        {
            if (book == null) return BadRequest("Model is empty");

            try
            {
                var result = await _bookService.UpdateBookAsync(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/books/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            if (id < 0) return BadRequest("Model is empty");

            try
            {
                var result = await _bookService.GetBookAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/books/reviews")]
        public async Task<IActionResult> AddReview([FromForm] AddReviewDTO review)
        {
            if (review == null) return BadRequest("Model is empty");

            try
            {
                var result = await _bookService.AddBookReviewAsync(review);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/books/reviews")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> DeleteReview([FromForm] int id)
        {
            if (id < 0) return BadRequest("Model is empty");

            try
            {
                var result = await _bookService.DeleteBookReviewAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/books/reviews")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateReview([FromForm] UpdateReviewDTO review)
        {
            if (review == null) return BadRequest("Model is empty");

            try
            {
                var result = await _bookService.UpdateBookReviewAsync(review);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/books/reviews")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> GetReview(int id)
        {
            if (id < 0) return BadRequest("Model is empty");

            try
            {
                var result = await _bookService.GetBookReviewAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
