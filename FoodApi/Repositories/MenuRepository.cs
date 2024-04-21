using FoodApi.Context;
using FoodApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Repositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetMenus();
        Task<Menu?> GetMenu(int id);
        Task<Menu> CreateMenu(Menu menu);
        Task<Menu> UpdateMenu(Menu menu);
        Task<Menu?> DeleteMenu(int id);

    }
    public class MenuRepository(ApplicationDbContext db) : IMenuRepository
    {

        //Obtener todos los menus
        public async Task<IEnumerable<Menu>> GetMenus()
        {
            return await db.Menu.ToListAsync();
        }

        //Obtener un menu
        public async Task<Menu?> GetMenu(int id)
        {
            return await db.Menu.FindAsync(id);
        }

        //Crear un menu
        public async Task<Menu> CreateMenu(Menu menu)
        {
            db.Menu.Add(menu);
            await db.SaveChangesAsync();
            return menu;
        }

        //Actualizar un menu
        public async Task<Menu> UpdateMenu(Menu menu)
        {
            db.Entry(menu).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return menu;
        }

        //Eliminar un menu
        public async Task<Menu?> DeleteMenu(int id)
        {
            Menu? menu = await db.Menu.FindAsync(id);
            if (menu == null) return menu;
            menu.IsDeleted = false;
            db.Entry(menu).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return menu;
        }
    }
}
