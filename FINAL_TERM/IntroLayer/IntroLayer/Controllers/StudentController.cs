using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroLayer.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/students/all")]
        public HttpResponseMessage GetAll()
        {
            var data = StudentService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/students/{id}")]
        public HttpResponseMessage Get(int id) 
        { 
             var data = StudentService.Get(id);
             return Request.CreateResponse(HttpStatusCode.OK,data);
        }


        [HttpPost]
        [Route("api/students/create")]
        public HttpResponseMessage Create(StudentDTO s)
        {
            StudentService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/students/update")]
        public HttpResponseMessage Update(StudentDTO s)
        { 
            StudentService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/students/delete/{id}")]
        public HttpResponseMessage Delete(int id) 
        { 
           StudentService.Delete(id);
           return Request.CreateResponse(HttpStatusCode.OK);
        }
        
    }
}
