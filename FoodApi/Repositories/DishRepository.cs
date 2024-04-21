using FoodApi.Context;
using FoodApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Repositories
{

    public interface IDishRepository
    {

        Task<IEnumerable<Dish>> GetDishes();
        Task<Dish?> GetDish(int id);
        Task<Dish> CreateDish(Dish dish);
        Task<Dish> UpdateDish(Dish dish);
        Task<Dish?> DeleteDish(int id);
    }

    public class DishRepository(ApplicationDbContext db): IDishRepository
    {
        //Obtener todos los platos
        public async Task<IEnumerable<Dish>> GetDishes()
        {
            return await db.Dish.ToListAsync();
        }

        //Obtener un plato
        public async Task<Dish?> GetDish(int id)
        {
            return await db.Dish.FindAsync(id);
        }

        //Crear un plato
        public async Task<Dish> CreateDish(Dish dish)
        {
            db.Dish.Add(dish);
            await db.SaveChangesAsync();
            return dish;
        }

        //Actualizar un plato
        public async Task<Dish> UpdateDish(Dish dish)
        {
            db.Entry(dish).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return dish;
        }

        //Eliminar un plato
        public async Task<Dish?> DeleteDish(int id)
        {
            Dish? dish = await db.Dish.FindAsync(id);
            if (dish == null) return dish;
            dish.IsDeleted = false;
            db.Entry(dish).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return dish;

        }
    }
}
