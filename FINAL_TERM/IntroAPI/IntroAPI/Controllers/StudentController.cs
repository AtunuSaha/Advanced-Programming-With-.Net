using IntroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace IntroAPI.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/student/all")]
        public HttpResponseMessage GetAll()
        {
            var students = new List<Student>();
            for (int i = 1; i <= 10; i++)
            {
                students.Add(new Student()
                {
                    Id = i,
                    Name = "S" + i
                }); ;
            }
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        [HttpPost]
        [Route("api/student/create")]
        public HttpResponseMessage Create(Student s)
        {
            //
            //
            s.Id = 1;
            return Request.CreateResponse(HttpStatusCode.OK, s);
        }
    }
}
