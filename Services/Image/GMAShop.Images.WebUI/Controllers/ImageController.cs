using GMAShop.Images.WebUI.Dal.Context;
using GMAShop.Images.WebUI.Dal.Entities;
using GMAShop.Images.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMAShop.Images.WebUI.Controllers
{
    public class ImageController(ICloudStorageService cloudStorageService, ImageContextDb context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var images = await context.Images.ToListAsync();
            foreach (var image in images)
            {
                await GenerateSignedUrl(image);
            }

            return View(images);
        }

        private async Task GenerateSignedUrl(Image image)
        {
            if (!string.IsNullOrWhiteSpace(image.SavedFileName))
            {
                image.SignedUrl = await cloudStorageService.GetSignedUrlAsync(image.SavedFileName);
            }
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Image image)
        {
            if (image.Photo != null)
            {
                image.SavedFileName = GenerateFileNameToSave(image.Photo.FileName);
                image.SavedUrl = await cloudStorageService.UploadFileAsync(image.Photo, image.SavedFileName);
            }

            context.Add(image);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Images == null)
            {
                return NotFound();
            }

            var image = await context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            await GenerateSignedUrl(image);
            return View(image);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photo,SavedUrl,SavedFileName")] Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await ReplacePhoto(image);
                    context.Update(image);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Image", "Admin");
            }

            return View(image);
        }

        private async Task ReplacePhoto(Image image)
        {
            if (image.Photo != null)
            {
                //replace the file by deleting image.SavedFileName file and then uploading new image.Photo
                if (!string.IsNullOrEmpty(image.SavedFileName))
                {
                    await cloudStorageService.DeleteFileAsync(image.SavedFileName);
                }

                image.SavedFileName = GenerateFileNameToSave(image.Photo.FileName);
                image.SavedUrl = await cloudStorageService.UploadFileAsync(image.Photo, image.SavedFileName);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (context.Images == null)
            {
                return Problem("Entity set is null.");
            }

            var image = await context.Images.FindAsync(id);
            if (image != null)
            {
                if (!string.IsNullOrWhiteSpace(image.SavedFileName))
                {
                    await cloudStorageService.DeleteFileAsync(image.SavedFileName);
                    image.SavedFileName = String.Empty;
                    image.SavedUrl = String.Empty;
                }

                context.Images.Remove(image);
            }

            await context.SaveChangesAsync();
            return RedirectToAction("Image", "Admin");
        }

        private bool ImageExists(int id)
        {
            return context.Images.Any(e => e.Id == id);
        }
    }
}