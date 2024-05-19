﻿using AutoMapper;
using GMAShop.Catalog.Dtos.CategoryDtos;
using GMAShop.Catalog.Dtos.ProductDetailDtos;
using GMAShop.Catalog.Dtos.ProductDtos;
using GMAShop.Catalog.Dtos.ProductImageDtos;
using GMAShop.Catalog.Entities;

namespace GMAShop.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryId>().ReverseMap();


        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();

        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<Product, CreateProductDetailDto>().ReverseMap();
        CreateMap<Product, UpdateProductDetailDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDetailDto>().ReverseMap();


        CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<Product, CreateProductImageDto>().ReverseMap();
        CreateMap<Product, UpdateProductImageDto>().ReverseMap();
        CreateMap<Product, GetByIdProductImageDto>().ReverseMap();
    }
}