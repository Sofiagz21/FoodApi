using FoodApi.Model;
using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace FoodApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class MenuDishController(IMenuDishService menuDishService): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMenuDishes()
        {
            IEnumerable<MenuDish> menuDishes = await menuDishService.GetMenuDishes();
            return Ok(menuDishes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMenuDish(int id)
        {
            MenuDish? menuDish = await menuDishService.GetMenuDish(id);
            if (menuDish == null) return NotFound();
            return Ok(menuDish);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuDish(
          int IdMenu,
          int IdDish,
          string Availability
         )
        {
            var menuDish = await menuDishService.CreateMenuDish(IdMenu, IdDish, Availability);
            return CreatedAtAction(nameof(GetMenuDish), new { id = menuDish.IdMenuDish }, menuDish);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenuDish(
            int IdMenuDish,
            int? IdMenu,
            int? IdDish,
            string? Availability
        )
        {
            var updatedMenuDish = await menuDishService.UpdateMenuDish(IdMenuDish, IdMenu, IdDish, Availability);
            return Ok(updatedMenuDish);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMenuDish(int id)
        {
            var deletedMenuDish = await menuDishService.DeleteMenuDish(id);
            if (deletedMenuDish == null) return NotFound();
            return Ok(deletedMenuDish);
        }
    }
}
