using AutoMapper;
using GMAShop.Catalog.Dtos.ProductDetailDtos;
using GMAShop.Catalog.Entities;
using GMAShop.Catalog.Settings;
using MongoDB.Driver;

namespace GMAShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;

    public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        var values = await _productDetailCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(values);
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var value = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _productDetailCollection.InsertOneAsync(value);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, value);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x => x.ProductId.Equals(id));
    }



    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        var value = await _productDetailCollection.Find(x => x.ProductId.Equals(id)).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDto>(value);
    }
}