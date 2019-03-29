using AutoMapper;
using FiralApiReal.Dtos;
using FiralApiReal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiralApiReal.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}
