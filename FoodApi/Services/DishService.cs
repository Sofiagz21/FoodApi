using FoodApi.Model;
using FoodApi.Repositories;

namespace FoodApi.Services
{
    public interface IDishService
    {
        Task<IEnumerable<Dish>> GetDishes();
        Task<Dish?> GetDish(int id);
        Task<Dish> CreateDish(
           string DishName,
           string DishDescription,
           int DishAvaliability,
           string DishPrice,
           int IdClassificationDish
         );
        Task<Dish> UpdateDish(
            int IdDish,
            string? DishName,
            string? DishDescription,
            int? DishAvaliability,
            string? DishPrice,
            int? IdClassificationDish
        );
        Task<Dish?> DeleteDish(int id);
    }
    public class DishService(IDishRepository dishRepository): IDishService
    {
        //Obtener todos los platillos
        public async Task<IEnumerable<Dish>> GetDishes()
        {
            return await dishRepository.GetDishes();
        }

        //Obtener un platillo
        public async Task<Dish?> GetDish(int id)
        {
            return await dishRepository.GetDish(id);
        }

        //Crear un platillo

        public async Task<Dish> CreateDish(
           string DishName,
           string DishDescription,
           int DishAvaliability,
           string DishPrice,
           int IdClassificationDish
        )
        {
            return await dishRepository.CreateDish(new Dish
            {
                DishName = DishName,
                DishDescription = DishDescription,
                DishAvaliability = DishAvaliability,
                DishPrice = DishPrice,
                IdClassificationDish = IdClassificationDish
            });
        }

        //Actualizar un platillo
        public async Task<Dish> UpdateDish(
           int IdDish,
           string? DishName,
           string? DishDescription,
           int? DishAvaliability,
           string? DishPrice,
            int? IdClassificationDish
        )
        {
            Dish? dish = await dishRepository.GetDish(IdDish);
            if (dish == null) throw new Exception("El platillo no existe");
            dish.DishName = DishName?? dish.DishName;
            dish.DishDescription = DishDescription?? dish.DishDescription;
            dish.DishAvaliability = DishAvaliability?? dish.DishAvaliability;
            dish.DishPrice = DishPrice?? dish.DishPrice;
            dish.IdClassificationDish = IdClassificationDish?? dish.IdClassificationDish;
            return await dishRepository.UpdateDish(dish);
        }

        //Eliminar un platillo
        public async Task<Dish?> DeleteDish(int id)
        {
            return await dishRepository.DeleteDish(id);
        }
    }
   
}
