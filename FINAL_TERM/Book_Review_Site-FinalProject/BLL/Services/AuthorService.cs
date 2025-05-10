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
    public class AuthorService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<AuthorDTO, Author>();
                cfg.CreateMap<Book, BookDTO>()
                    .ForMember(dest => dest.AuthorName,
                        opt => opt.MapFrom(src => src.Author.Name));
            });
            return new Mapper(config);
        }

        public static List<AuthorDTO> Get()
        {
            var repo = DataAccessFactory.AuthorData();
            var data = repo.Get();
            return GetMapper().Map<List<AuthorDTO>>(data);
        }

        public static AuthorDTO Get(int id)
        {
            var repo = DataAccessFactory.AuthorData();
            var author = repo.Get(id);
            return GetMapper().Map<AuthorDTO>(author);
        }

        public static AuthorDTO Create(AuthorDTO author)
        {
            var repo = DataAccessFactory.AuthorData();
            var mapper = GetMapper();
            var authorEntity = mapper.Map<Author>(author);
            var createdAuthor = repo.Create(authorEntity);
            return mapper.Map<AuthorDTO>(createdAuthor);
        }

        public static AuthorDTO Update(AuthorDTO author)
        {
            var repo = DataAccessFactory.AuthorData();
            var mapper = GetMapper();
            var authorEntity = mapper.Map<Author>(author);
            var updatedAuthor = repo.Update(authorEntity);
            return mapper.Map<AuthorDTO>(updatedAuthor);
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.AuthorData();
            return repo.Delete(id);
        }
    }
}
