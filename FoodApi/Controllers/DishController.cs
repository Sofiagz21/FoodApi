using FoodApi.Model;
using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DishController(IDishService dishService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
            return Ok(await dishService.GetDishes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDish(int id)
        {
            Dish? dish = await dishService.GetDish(id);
            if (dish == null) return NotFound();
            return Ok(dish);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDish(

           string DishName,
           string DishDescription,
           int DishAvaliability,
           string DishPrice,
           int IdClassificationDish
        )
        {
            var dish = await dishService.CreateDish(DishName, DishDescription, DishAvaliability, DishPrice, IdClassificationDish);
            return CreatedAtAction(nameof(GetDish), new { id = dish.IdDish }, dish);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDish(
           int IdDish,
           string? DishName,
           string? DishDescription,
           int? DishAvaliability,
           string? DishPrice,
           int? IdClassificationDish
        )
        {
            var updatedDish = await dishService.UpdateDish(IdDish, DishName, DishDescription, DishAvaliability, DishPrice, IdClassificationDish);
            return Ok(updatedDish);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            var dish = await dishService.DeleteDish(id);
            if (dish == null) return NotFound();
            return Ok(dish);
        }
    }
}
