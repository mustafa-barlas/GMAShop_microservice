using AutoMapper;
using GMAShop.Catalog.Dtos.ProductImageDtos;
using GMAShop.Catalog.Entities;
using GMAShop.Catalog.Settings;
using MongoDB.Driver;

namespace GMAShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductImage> _productImageCollection;

    public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        var values = await _productImageCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDto>>(values);
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        var value = _mapper.Map<ProductImage>(createProductImageDto);
        await _productImageCollection.InsertOneAsync(value);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        var value = _mapper.Map<ProductImage>(updateProductImageDto);
        await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductImageDto.ProductId, value);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _productImageCollection.DeleteOneAsync(x => x.ProductId.Equals(id));
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        var value = await _productImageCollection.Find(x => x.ProductId.Equals(id)).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDto>(value);
    }
}