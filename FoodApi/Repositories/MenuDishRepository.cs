using FoodApi.Context;
using FoodApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Repositories
{
    
    public interface IMenuDishRepository
    {
        Task<IEnumerable<MenuDish>> GetMenuDishes();
        Task<MenuDish?> GetMenuDish(int id);
        Task<MenuDish> CreateMenuDish(MenuDish menuDish);
        Task<MenuDish> UpdateMenuDish(MenuDish menuDish);
        Task<MenuDish?> DeleteMenuDish(int id);

    }
    public class MenuDishRepository(ApplicationDbContext db): IMenuDishRepository
    {
        //Obtener todos los platos de menu
        public async Task<IEnumerable<MenuDish>> GetMenuDishes()
        {
            return await db.MenuDish.ToListAsync();
        }

        //Obtener un plato de menu
        public async Task<MenuDish?> GetMenuDish(int id)
        {
            return await db.MenuDish.FindAsync(id);
        }

        //Crear un plato de menu
        public async Task<MenuDish> CreateMenuDish(MenuDish menuDish)
        {
            db.MenuDish.Add(menuDish);
            await db.SaveChangesAsync();
            return menuDish;
        }

        //Actualizar un plato de menu
        public async Task<MenuDish> UpdateMenuDish(MenuDish menuDish)
        {
            db.Entry(menuDish).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return menuDish;
        }

        //Eliminar un plato de menu
        public async Task<MenuDish?> DeleteMenuDish(int id)
        {
            MenuDish? menuDish = await db.MenuDish.FindAsync(id);
            if (menuDish == null) return menuDish;
            menuDish.IsDeleted = false;
            db.Entry(menuDish).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return menuDish;
        }
    }
    
}
