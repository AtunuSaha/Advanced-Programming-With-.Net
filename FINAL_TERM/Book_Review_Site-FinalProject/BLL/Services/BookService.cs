using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Services
{
    public class BookService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Book, BookDTO>()
                    .ForMember(dest => dest.AuthorName,
                        opt => opt.MapFrom(src => src.Author.Name));
                cfg.CreateMap<BookDTO, Book>();
            });
            return new Mapper(config);
        }

        public static List<BookDTO> Get()
        {
            var repo = DataAccessFactory.BookData();
            var data = repo.Get();
            return GetMapper().Map<List<BookDTO>>(data);
        }

        public static BookDTO Get(int id)
        {
            var repo = DataAccessFactory.BookData();
            var book = repo.Get(id);
            return GetMapper().Map<BookDTO>(book);
        }
        

        public static List<BookDTO> SearchByTitle(string title)
        {
            var repo = DataAccessFactory.BookFeatures();
            return GetMapper().Map<List<BookDTO>>(repo.SearchByTitle(title));
        }
        public static List<BookDTO> SearchByAuthor(string authorName)
        {
            var repo = DataAccessFactory.BookFeatures();
            return GetMapper().Map<List<BookDTO>>(repo.SearchByAuthor(authorName));
        }

        public static List<BookDTO> GetRecommendations(int bookId)
        {
            var repo = DataAccessFactory.BookFeatures();
            var byAuthor = repo.GetRecommendationsByAuthor(bookId);
            var byGenre = repo.GetRecommendationsByGenre(bookId);
            var recommendations = byAuthor.Union(byGenre).Distinct().ToList();
            return GetMapper().Map<List<BookDTO>>(recommendations);
        }


        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.BookData();
            return repo.Delete(id);
        }

        public static BookDTO Update(BookDTO book)
        {
            var repo = DataAccessFactory.BookData();

           
            var existingBook = repo.Get(book.Id);
            if (existingBook != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<BookDTO, Book>();
                    cfg.CreateMap<Book, BookDTO>();
                });
                var mapper = new Mapper(config);
                var bookEntity = mapper.Map<Book>(book);

                
                bookEntity.Author = existingBook.Author; 

                var updatedBook = repo.Update(bookEntity);
                return mapper.Map<BookDTO>(updatedBook);
            }
            return null;
        }
        public static BookDTO Create(BookDTO book)
        {
            var repo = DataAccessFactory.BookData();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<Book, BookDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Book>(book);
            var createdBook = repo.Create(data);
            return mapper.Map<BookDTO>(createdBook);
        }

    }
}
