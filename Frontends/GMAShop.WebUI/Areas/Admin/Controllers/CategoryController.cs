using Microsoft.AspNetCore.Mvc;
using GMAShop.DtoLayer.CatalogDtos.CategoryDtos;
using GMAShop.WebUI.Services.CatalogServices.CategoryServices;

namespace GMAShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Category")]
public class CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
    : Controller
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        CategoryViewbagList();
        var values = await categoryService.GetAllCategoryAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateCategory")]
    public IActionResult CreateCategory()
    {
        CategoryViewbagList();
        return View();
    }

    [HttpPost]
    [Route("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        await categoryService.CreateCategoryAsync(createCategoryDto);
        return RedirectToAction("Index", "Category", new { area = "Admin" });
    }

    [Route("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await categoryService.DeleteCategoryAsync(id);
        return RedirectToAction("Index", "Category", new { area = "Admin" });
    }

    [Route("UpdateCategory/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateCategory(string id)
    {
        CategoryViewbagList();
        var values = await categoryService.GetByIdCategoryAsync(id);
        return View(values);
    }

    [Route("UpdateCategory/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        await categoryService.UpdateCategoryAsync(updateCategoryDto);
        return RedirectToAction("Index", "Category", new { area = "Admin" });
    }

    void CategoryViewbagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Kategoriler";
        ViewBag.v3 = "Kategori Listesi";
        ViewBag.v0 = "Kategori İşlemleri";
    }
}