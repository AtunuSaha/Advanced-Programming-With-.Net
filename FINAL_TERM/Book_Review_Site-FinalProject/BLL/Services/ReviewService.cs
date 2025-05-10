using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReviewService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Review, ReviewDTO>()
                    .ForMember(dest => dest.BookTitle,
                        opt => opt.MapFrom(src => src.Book.Title))
                    .ForMember(dest => dest.ReviewerName,
                        opt => opt.MapFrom(src => src.Reviewer.Name));
                cfg.CreateMap<ReviewDTO, Review>();
            });
            return new Mapper(config);
        }

        public static List<ReviewDTO> Get()
        {
            var repo = DataAccessFactory.ReviewData();
            var data = repo.Get();
            return GetMapper().Map<List<ReviewDTO>>(data);
        }

        public static ReviewDTO Get(int id)
        {
            var repo = DataAccessFactory.ReviewData();
            var review = repo.Get(id);
            return GetMapper().Map<ReviewDTO>(review);
        }

        public static List<ReviewDTO> GetReviewsByBook(int bookId)
        {
            var repo = DataAccessFactory.ReviewFeatures();
            var reviews = repo.GetReviewsByBook(bookId);
            return GetMapper().Map<List<ReviewDTO>>(reviews);
        }

        public static List<ReviewDTO> GetReviewsByReviewer(int reviewerId)
        {
            var repo = DataAccessFactory.ReviewFeatures();
            var reviews = repo.GetReviewsByReviewer(reviewerId);
            return GetMapper().Map<List<ReviewDTO>>(reviews);
        }

        public static List<ReviewDTO> SearchByBookTitle(string title)
        {
            var repo = DataAccessFactory.ReviewFeatures();
            var reviews = repo.SearchByBookTitle(title);
            return GetMapper().Map<List<ReviewDTO>>(reviews);
        }

       
        public static ReviewDTO Create(ReviewDTO review)
        {
            var repo = DataAccessFactory.ReviewData();
            var mapper = GetMapper();
            var reviewEntity = mapper.Map<Review>(review);
            var createdReview = repo.Create(reviewEntity);
            return mapper.Map<ReviewDTO>(createdReview);
        }

        public static ReviewDTO Update(ReviewDTO review)
        {
            var repo = DataAccessFactory.ReviewData();
            var mapper = GetMapper();
            var reviewEntity = mapper.Map<Review>(review);
            var updatedReview = repo.Update(reviewEntity);
            return mapper.Map<ReviewDTO>(updatedReview);
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.ReviewData();
            return repo.Delete(id);
        }
    }
}
