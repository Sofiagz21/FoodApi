using FoodApi.Model;
using FoodApi.Repositories;

namespace FoodApi.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetMenus();
        Task<Menu?> GetMenu(int id);
        Task<Menu> CreateMenu(
          string MenuName,
          string MenuDescription
        );
        Task<Menu> UpdateMenu(
          int IdMenu,
          string? MenuName,
          string? MenuDescription
        );
        
        Task<Menu?> DeleteMenu(int id);
    }
    public class MenuService(IMenuRepository menuRepository) : IMenuService
    {
        //Obtener todos los menus
        public async Task<IEnumerable<Menu>> GetMenus()
        {
            return await menuRepository.GetMenus();
        }

        //Obtener un menu
        public async Task<Menu?> GetMenu(int id)
        {
            return await menuRepository.GetMenu(id);
        }

        //Crear un menu

        public async Task<Menu> CreateMenu(
           string MenuName,
           string MenuDescription
        )
        {
            return await menuRepository.CreateMenu(new Menu
            {
                MenuName = MenuName,
                MenuDescription = MenuDescription
            });
        }

        //Actualizar un menu
        public async Task<Menu> UpdateMenu(
          int IdMenu,
          string? MenuName,
          string? MenuDescription
        )
        {
            Menu? menu = await menuRepository.GetMenu(IdMenu);
            if (menu == null) throw new Exception("El menu no existe");
            menu.MenuName = MenuName?? menu.MenuName;
            menu.MenuDescription = MenuDescription?? menu.MenuDescription;
            return await menuRepository.UpdateMenu(menu);
        }

        //Eliminar un menu
        public async Task<Menu?> DeleteMenu(int id)
        {
            return await menuRepository.DeleteMenu(id);
        }
    }
}
