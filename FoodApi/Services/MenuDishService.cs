using FoodApi.Model;
using FoodApi.Repositories;

namespace FoodApi.Services
{

    public interface IMenuDishService
    {
        Task<IEnumerable<MenuDish>> GetMenuDishes();
        Task<MenuDish?> GetMenuDish(int id);
        Task<MenuDish> CreateMenuDish(
           int IdMenu,
           int IdDish,
           string Availability
        );
       
        Task<MenuDish> UpdateMenuDish(
         int IdMenuDish,
         int? IdMenu,
         int? IdDish,
         string? Availability
       );
        
        Task<MenuDish?> DeleteMenuDish(int id);
    }
    public class MenuDishService(IMenuDishRepository menuDishRepository) : IMenuDishService
    {
        //Obtener todos los platos de menu
        public async Task<IEnumerable<MenuDish>> GetMenuDishes()
        {
            return await menuDishRepository.GetMenuDishes();
        }

        //Obtener un plato de menu
        public async Task<MenuDish?> GetMenuDish(int id)
        {
            return await menuDishRepository.GetMenuDish(id);
        }

        //Crear un plato de menu

        public async Task<MenuDish> CreateMenuDish(
          int IdMenu,
          int IdDish,
          string Availability
         )
        {
            return await menuDishRepository.CreateMenuDish(new MenuDish
            {
                IdMenu = IdMenu,
                IdDish = IdDish,
                Availability = Availability
            });
        }

        //Actualizar un plato de menu
        public async Task<MenuDish> UpdateMenuDish(
              int IdMenuDish,
              int? IdMenu,
              int? IdDish,
              string? Availability
         )
        {
            MenuDish? menuDish = await menuDishRepository.GetMenuDish(IdMenuDish);
            if (menuDish == null) throw new Exception("El plato de menu no existe");
            menuDish.IdMenu = IdMenu?? menuDish.IdMenu;
            menuDish.IdDish = IdDish?? menuDish.IdDish;
            menuDish.Availability = Availability?? menuDish.Availability;
            return await menuDishRepository.UpdateMenuDish(menuDish);

        }

        //Eliminar un plato de menu
        public async Task<MenuDish?> DeleteMenuDish(int id)
        {
            return await menuDishRepository.DeleteMenuDish(id);
        }
    }
    
}
