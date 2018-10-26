using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile:Profile
    {
        public static void Run()

        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<MappingProfile>();
            });

        }

        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Movie, MovieDto>();

        }
    }
}