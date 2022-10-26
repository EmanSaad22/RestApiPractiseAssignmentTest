using AutoMapper;
using DomainLayer.Models;
using RestApiPractiseAssignmentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiPractiseAssignmentApi.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryModel>()
                .ForMember(
                dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(
                dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.ID)
                );

            CreateMap<CategoryCreationModel, Category>();

        }
    }
}
