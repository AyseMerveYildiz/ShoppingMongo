using AutoMapper;
using MongoDB.Driver;
using ShoppingMongo.Entities;
using ShoppingMongo.Settings;
using ShoppingMongo.Dtos.ProductDtos;

namespace ShoppingMongo.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<ProductImage> _productImageCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {

            // Veritabanından tüm veriler çekiliyor
            var products = await _productCollection.Find(x => true).ToListAsync();
            var categories = await _categoryCollection.Find(x => true).ToListAsync();
            var images = await _productImageCollection.Find(x => true).ToListAsync();

            // Ürünler üzerinde dönerek DTO’ya dönüştürme işlemi yapılıyor
            var result = products.Select(product =>
            {
                // AutoMapper ile temel dönüşüm
                var dto = _mapper.Map<ResultProductDto>(product);

                // Kategori eşleşmesi (FirstOrDefault ile)
                var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
                dto.CategoryName = category != null ? category.CategoryName : null;

                // Ürüne ait resimleri bulma
                var productImages = images
                    .Where(img => img.ProductId == product.ProductId)
                    .Select(img => img.ImageUrl)
                    .ToList();

                dto.ImageUrl = productImages;

                return dto;
            }).ToList();

            return result;
        }



        public async Task<GetProductDto> GetProductByIdAsync(string id)
        {
            var product = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<GetProductDto>(product);

            var category = await _categoryCollection.Find(c => c.CategoryId == product.CategoryId).FirstOrDefaultAsync();
            dto.CategoryName= category?.CategoryName;

            var images = await _productImageCollection.Find(i => i.ProductId == product.ProductId).ToListAsync();
            dto.ImageUrl = images.Select(i => i.ImageUrl).ToList();

            return dto;
        }


        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, product);
        }
    }
}

