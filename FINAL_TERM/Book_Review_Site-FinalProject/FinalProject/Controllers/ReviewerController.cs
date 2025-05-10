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
    public class ReviewerController : ApiController
    {
        [HttpGet]
        [Route("api/reviewers/getall")]
        public HttpResponseMessage Get()
        {
            var data = ReviewerService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/reviewers/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ReviewerService.Get(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Reviewer not found");
        }

        [HttpPost]
        [Route("api/reviewers/create")]
        public HttpResponseMessage Create(ReviewerDTO reviewer)
        {
            var data = ReviewerService.Create(reviewer);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        [HttpPut]
        [Route("api/reviewers/update")]
        public HttpResponseMessage Update(ReviewerDTO reviewer)
        {
            var data = ReviewerService.Update(reviewer);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Reviewer not found");
        }

        [HttpDelete]
        [Route("api/reviewers/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = ReviewerService.Delete(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Reviewer deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Reviewer not found");
        }
    }
}
