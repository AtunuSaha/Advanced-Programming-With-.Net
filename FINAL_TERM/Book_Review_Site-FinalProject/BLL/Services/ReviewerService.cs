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
    public class ReviewerService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Reviewer, ReviewerDTO>();
                cfg.CreateMap<ReviewerDTO, Reviewer>();
                cfg.CreateMap<Review, ReviewDTO>()
                    .ForMember(dest => dest.BookTitle,
                        opt => opt.MapFrom(src => src.Book.Title));
            });
            return new Mapper(config);
        }

        public static List<ReviewerDTO> Get()
        {
            var repo = DataAccessFactory.ReviewerData();
            var data = repo.Get();
            return GetMapper().Map<List<ReviewerDTO>>(data);
        }

        public static ReviewerDTO Get(int id)
        {
            var repo = DataAccessFactory.ReviewerData();
            var reviewer = repo.Get(id);
            return GetMapper().Map<ReviewerDTO>(reviewer);
        }
        public static ReviewerDTO Create(ReviewerDTO reviewer)
        {
            var repo = DataAccessFactory.ReviewerData();
            var mapper = GetMapper();
            var reviewerEntity = mapper.Map<Reviewer>(reviewer);
            var createdReviewer = repo.Create(reviewerEntity);
            return mapper.Map<ReviewerDTO>(createdReviewer);
        }

        public static ReviewerDTO Update(ReviewerDTO reviewer)
        {
            var repo = DataAccessFactory.ReviewerData();
            var mapper = GetMapper();
            var reviewerEntity = mapper.Map<Reviewer>(reviewer);
            var updatedReviewer = repo.Update(reviewerEntity);
            return mapper.Map<ReviewerDTO>(updatedReviewer);
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.ReviewerData();
            return repo.Delete(id);
        }
    }
}
