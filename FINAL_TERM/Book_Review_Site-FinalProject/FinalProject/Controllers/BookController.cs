using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class BookController : ApiController
    {
        [HttpGet]
        [Route("api/books/getall")]
        public HttpResponseMessage Get()
        {
            var data = BookService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/books/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = BookService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/books/searchbytitle/{title}")]
        public HttpResponseMessage SearchTitle(string title = null)
        {
            if (!string.IsNullOrEmpty(title))
            {
                var data = BookService.SearchByTitle(title);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Please provide a title ");
        }

        [HttpGet]
        [Route("api/books/searchbyauthor/{authorName}")]
        public HttpResponseMessage SearchAuthor(string authorName = null)
        {
            if (!string.IsNullOrEmpty(authorName))
            {
                var data = BookService.SearchByAuthor(authorName);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, "Please provide a author ");
        }
        [HttpGet]
        [Route("api/books/recommendations/{id}")]
        public HttpResponseMessage GetRecommendations(int id)
        {
            var data = BookService.GetRecommendations(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/books/create")]
        public HttpResponseMessage Create(BookDTO book)
        {
            var data = BookService.Create(book);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        [HttpPut]
        [Route("api/books/update")]
        public HttpResponseMessage Update(BookDTO book)
        {
            var data = BookService.Update(book);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Book not found");
        }

        [HttpDelete]
        [Route("api/books/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = BookService.Delete(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Book deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Book not found");
        }

    }
}
