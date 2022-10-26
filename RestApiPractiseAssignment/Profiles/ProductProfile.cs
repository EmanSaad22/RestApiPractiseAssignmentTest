using AutoMapper;
using DomainLayer.Models;
using RestApiPractiseAssignmentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiPractiseAssignmentApi.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductModel>()
                .ForMember(
                dest => dest.ProductName,
                opt => opt.MapFrom(src=>src.Name))
                .ForMember(
                dest => dest.ProductId,
                opt => opt.MapFrom(src => src.ID))
                .ForMember
                (
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price))
                .ForMember
                (
                dest => dest.Quantity,
                opt => opt.MapFrom(src => src.Quantity))
                .ForMember
                (
                dest => dest.ImgURL,
                opt => opt.MapFrom(src => src.ImgURL))
                .ForMember
                (
                dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.CategoryId));

            CreateMap<ProductCreationModel, Products>()
                .ForMember(
                dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}
