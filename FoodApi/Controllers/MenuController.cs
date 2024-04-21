using FoodApi.Model;
using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MenuController(IMenuService menuService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            IEnumerable<Menu> menus = await menuService.GetMenus();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu(int id)
        {
            Menu? menu = await menuService.GetMenu(id);
            if (menu == null) return NotFound();
            return Ok(menu);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(
          string MenuName,
          string MenuDescription
        )
        {
            var menu = await menuService.CreateMenu(MenuName, MenuDescription);
            return CreatedAtAction(nameof(GetMenu), new { id = menu.IdMenu }, menu);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenu(
           int IdMenu,
           string? MenuName,
           string? MenuDescription
        )
        {
            var updatedMenu = await menuService.UpdateMenu(IdMenu, MenuName, MenuDescription);
            return Ok(updatedMenu);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await menuService.DeleteMenu(id);
            if (menu == null) return NotFound();
            return Ok(menu);
        }
    }
}
