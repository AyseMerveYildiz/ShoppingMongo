using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingMongo.Dtos.ProductDtos;
using ShoppingMongo.Services.CategoryServices;
using ShoppingMongo.Services.ProductServices;

namespace ShoppingNightMongo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> ProductList()
        {
            var values= await _productService.GetAllProductAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.v = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId
            }).ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
          
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.v = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId
            }).ToList();

            var product = await _productService.GetProductByIdAsync(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            updateProductDto.Status = true;
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductList");
        }
    }
}
