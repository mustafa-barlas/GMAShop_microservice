using GMAShop.Catalog.Dtos.AboutDtos;
using GMAShop.Catalog.Services.AboutServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService aboutService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await aboutService.GetAllAboutAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var values = await aboutService.GetByIdAboutAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await aboutService.CreateAboutAsync(createAboutDto);
            return Ok("Hakkımda alanı başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await aboutService.DeleteAboutAsync(id);
            return Ok("Hakkımda alanı başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await aboutService.UpdateAboutAsync(updateAboutDto);
            return Ok("Hakkımda alanı başarıyla güncellendi");
        }
    }
}