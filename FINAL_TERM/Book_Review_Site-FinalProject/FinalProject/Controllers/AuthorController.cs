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
    public class AuthorController : ApiController
    {
        [HttpGet]
        [Route("api/authors/getall")]
        public HttpResponseMessage Get()
        {
            var data = AuthorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/authors/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = AuthorService.Get(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Author not found");
        }

        [HttpPost]
        [Route("api/authors/create")]
        public HttpResponseMessage Create(AuthorDTO author)
        {
            var data = AuthorService.Create(author);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        [HttpPut]
        [Route("api/authors/update")]
        public HttpResponseMessage Update(AuthorDTO author)
        {
            var data = AuthorService.Update(author);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Author not found");
        }

        [HttpDelete]
        [Route("api/authors/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = AuthorService.Delete(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Author deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Author not found");
        }
    }
}
