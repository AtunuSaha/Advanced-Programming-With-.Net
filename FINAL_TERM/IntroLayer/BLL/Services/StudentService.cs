﻿using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentDTO, Student>();
            });
            var mapper = new Mapper(config);
            return mapper;

        }
        public static List<StudentDTO> GetAll()
        {
            var repo = new StudentRepo();
            var data = repo.Get();
            var ret = GetMapper().Map<List<StudentDTO>>(data);
            return ret;

        }
        public static void Create(StudentDTO s)
        {
            //convert to EF model

            var ret = GetMapper().Map<Student>(s);
            var repo = new StudentRepo();
            repo.Create(ret);
        }

        public static StudentDTO Get(int id)
        {
            var prepo = new StudentRepo();
            var data = prepo.Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, StudentDTO>();
            });
            var mapper = new Mapper(config); ;
            var ret = mapper.Map<StudentDTO>(data);
            return ret;
        }

        public static void Update(StudentDTO s)
        { 
            var ret = GetMapper().Map<Student>(s);
            var repo = new StudentRepo();
            repo.Update(ret);
        }

        public static void Delete(int id)
        {
            var repo = new StudentRepo();
            repo.Delete(id);
        }
    }
}
