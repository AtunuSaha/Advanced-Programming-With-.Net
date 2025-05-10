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
    public class ReviewController : ApiController
    {
        [HttpGet]
        [Route("api/reviews/getall")]
        public HttpResponseMessage Get()
        {
            var data = ReviewService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/reviews/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ReviewService.Get(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Review not found");
        }

        [HttpGet]
        [Route("api/reviews/getbybook/{bookId}")]
        public HttpResponseMessage GetByBook(int bookId)
        {
            var data = ReviewService.GetReviewsByBook(bookId);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No reviews found for this book");
        }

        [HttpGet]
        [Route("api/reviews/getbyreviewer/{reviewerId}")]
        public HttpResponseMessage GetByReviewer(int reviewerId)
        {
            var data = ReviewService.GetReviewsByReviewer(reviewerId);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No reviews found for this reviewer");
        }

        [HttpPost]
        [Route("api/reviews/create")]
        public HttpResponseMessage Create(ReviewDTO review)
        {
            var data = ReviewService.Create(review);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        [HttpPut]
        [Route("api/reviews/update")]
        public HttpResponseMessage Update(ReviewDTO review)
        {
            var data = ReviewService.Update(review);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Review not found");
        }

        [HttpDelete]
        [Route("api/reviews/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = ReviewService.Delete(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Review deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Review not found");
        }

        [HttpGet]
        [Route("api/reviews/searchbytitle/{title}")]
        public HttpResponseMessage SearchByBookTitle(string title)
        {
            var data = ReviewService.SearchByBookTitle(title);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No reviews found for books with this title");
        }

        
    }
}
