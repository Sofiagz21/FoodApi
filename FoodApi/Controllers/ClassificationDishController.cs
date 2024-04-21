using FoodApi.Model;
using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationDishController(IClassificationDishService classificationDishService) : ControllerBase
    {
        [HttpGet]
        
        public async Task<IActionResult> GetClassificationDishes()
        {
            IEnumerable<ClassificationDish> classificationDishes = await classificationDishService.GetClassificationDishes();
            return Ok(classificationDishes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClassificationDish(int id)
        {
            ClassificationDish? classificationDish = await classificationDishService.GetClassificationDish(id);
            if (classificationDish == null) return NotFound();
            return Ok(classificationDish);
        }

        [HttpPost]

        public async Task<IActionResult> CreateClassificationDish(
           string ClassificationDishName,
           string ClassificationDishDescription
         )
        {
            var classificationDish = await classificationDishService.CreateClassificationDish(ClassificationDishName, ClassificationDishDescription);
            return CreatedAtAction(nameof(GetClassificationDish), new { id = classificationDish.IdClassificationDish }, classificationDish);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateClassificationDish(
           int IdClassificationDish,
           string? ClassificationDishName,
           string? ClassificationDishDescription
         )
        {
           var classificationDish = await classificationDishService.UpdateClassificationDish(IdClassificationDish, ClassificationDishName, ClassificationDishDescription);
            return Ok(classificationDish);
              
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClassificationDish(int id)
        {
            var deletedClassificationDish = await classificationDishService.DeleteClassificationDish(id);
            if (deletedClassificationDish == null) return NotFound();
            return Ok(deletedClassificationDish);
        }
    }
}
