using AutoMapper;
using GMAShop.Catalog.Dtos.FeatureSliderDtos;
using GMAShop.Catalog.Entities;
using GMAShop.Catalog.Settings;
using MongoDB.Driver;

namespace GMAShop.Catalog.Services.FeatureSliderService;

public class FeatureSliderService : IFeatureSliderService
{

    private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
    private readonly IMapper _mapper;


    public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);

    }

    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
    {
        var values = await _featureSliderCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultFeatureSliderDto>>(values);

    }

    public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
    {
        var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
        await _featureSliderCollection.InsertOneAsync(value);
    }

    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
        await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId.Equals(updateFeatureSliderDto.FeatureSliderId), value);

    }

    public async Task DeleteFeatureSliderAsync(string id)
    {
        await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId.Equals(id));
    }

    public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
    {
        var values = await _featureSliderCollection.Find(x => x.FeatureSliderId.Equals(id)).FirstAsync();
        return _mapper.Map<GetByIdFeatureSliderDto>(values);
    }

    public Task FeatureSliderChangeStatusToTrue(string id)
    {
        throw new NotImplementedException();
    }

    public async Task FeatureSliderChangeStatusToFalse(string id)
    {
        throw new NotImplementedException();
    }
}