using EduHubEntity;
using EduHubInterface;
using Microsoft.AspNetCore.Mvc;

namespace EduHubBd.Controllers.SuperAdmin
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperAdminRestaurantsController : ControllerBase
    {
        private IRestaurantAdminRepository restaurantRepo;
        public SuperAdminRestaurantsController(IRestaurantAdminRepository _restaurentRepo)
        {
            this.restaurantRepo = _restaurentRepo;
        }


        [Route("CreateRestaurant")]
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(RestaurantAdmin restaurantAdmin)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    await this.restaurantRepo.InsertAsync(restaurantAdmin);
                    return Ok(new { result = true });
                }
                return Ok(new { result = false });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("GetAllRestaurantsBySearch")]
        [HttpGet()]
        public async Task<IActionResult> GetAllBySearch(string searchText, string searchFilter, int pageNumber, int pageSize)
        {
            try
            {
                List<RestaurantAdmin> restaurants = await this.restaurantRepo.SearchAsync(searchText, searchFilter, pageNumber, pageSize);
                return Ok(new { restaurants });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
