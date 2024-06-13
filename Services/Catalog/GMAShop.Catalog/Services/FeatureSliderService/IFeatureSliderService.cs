﻿using GMAShop.Catalog.Dtos.FeatureSliderDtos;

namespace GMAShop.Catalog.Services.FeatureSliderService;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
    Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
    Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
    Task DeleteFeatureSliderAsync(string id);
    Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);

    Task FeatureSliderChangeStatusToTrue(string id);
    Task FeatureSliderChangeStatusToFalse(string id);
}