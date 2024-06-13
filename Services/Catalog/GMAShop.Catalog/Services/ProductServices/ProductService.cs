using AutoMapper;
using GMAShop.Catalog.Dtos.ProductDtos;
using GMAShop.Catalog.Entities;
using GMAShop.Catalog.Settings;
using MongoDB.Driver;

namespace GMAShop.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMongoCollection<Category> _categoryCollection;

    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var values = await _productCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(values);
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var value = _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(value);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var value = _mapper.Map<Product>(updateProductDto);
        await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.ProductId.Equals(id));
    }

    public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
    {
        var value = await _productCollection.Find(x => x.ProductId.Equals(id)).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDto>(value);
    }

    public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
    {


        var values = await _productCollection.Find(x => true).ToListAsync();

        foreach (var item in values)
        {
            item.Category = await _categoryCollection.Find(x => x.CategoryId.Equals(item.CategoryId)).FirstAsync();
        }
        return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);

        //var products = await _productCollection.Find(_ => true).ToListAsync();

        //var categoryIds = products.Select(p => p.CategoryId).Distinct().ToList();

        //var categories = await _categoryCollection.Find(c => categoryIds.Contains(c.CategoryId)).ToListAsync();


        //foreach (var product in products)
        //{
        //    product.Category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
        //}


        //return _mapper.Map<List<ResultProductsWithCategoryDto>>(products);
    }

}