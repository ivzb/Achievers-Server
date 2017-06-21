using Achievers.Infrastructure;
using Achievers.Infrastructure.Extensions;
using Achievers.Infrastructure.Validation;
using Achievers.Models;
using Achievers.Models.Cars;
using Achievers.Models.Rentings;
using Achievers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Achievers.Controllers
{
    public class CarsController : Controller
    {
        private readonly IImagesService images;
        private readonly ICarsService cars;
        private readonly UserManager<User> userManager;

        public CarsController(
            IImagesService images,
            ICarsService cars,
            UserManager<User> userManager)
        {
            this.images = images;
            this.cars = cars;
            this.userManager = userManager;
        }

        [Authorize(Roles = Constants.AdminRole)]
        [HttpGet]
        public IActionResult Add() => View();

        [Authorize(Roles = Constants.AdminRole)]
        [HttpPost]
        [ValidateActionParameters]
        [ValidateModel]
        public async Task<IActionResult> Add(CreateCarViewModel car, [Image]IFormFile image)
        {
            if (image != null)
            {
                var imageId = await this.images.SaveImageAsync(image.OpenReadStream());

                var carId = await this.cars.CreateAsync(
                    car.Make,
                    car.Model,
                    car.Year,
                    car.PricePerDay,
                    imageId);

                return RedirectToAction("Details", new { id = carId });
            }

            return View(car);
        }

        public async Task<IActionResult> All([FromQuery]CarRequestModel request)
        {
            var cars = await this.cars.AllAsync(
                request.Page,
                CarRequestModel.PageSize,
                request.Search);

            return View(cars);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
            => await this.ViewOrNotFound(async () => await this.cars.FindAsync(id));

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Rent(
            RentCarViewModel model,
            [FromServices]IRentingsService rentings)
        {
            var userId = this.userManager.GetUserId(User);

            var carPricePerDay = await this.cars.GetCarPriceAsync(model.CarId);

            await rentings.Rent(
                model.CarId,
                userId,
                model.Days,
                carPricePerDay);

            return this.Ok();
        }
    }
}
