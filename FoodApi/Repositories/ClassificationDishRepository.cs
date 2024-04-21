using FoodApi.Context;
using FoodApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Repositories
{
    public interface IClassificationDishRepository
    {
        Task<IEnumerable<ClassificationDish>> GetClassificationDishes();
        Task<ClassificationDish?> GetClassificationDish(int id);
        Task<ClassificationDish> CreateClassificationDish(ClassificationDish classificationDish);
        Task<ClassificationDish> UpdateClassificationDish(ClassificationDish classificationDish);
        Task<ClassificationDish?> DeleteClassificationDish(int id);
    }

    public class ClassificationDishRepository(ApplicationDbContext db) : IClassificationDishRepository
    {
        //Obtener todas las clasificaciones de platos
        public async Task<ClassificationDish?> GetClassificationDish(int id)
        {
            return await db.ClassificationDish.FindAsync(id);
        }

        //Obtener todas las clasificaciones de platos
        public async Task<IEnumerable<ClassificationDish>> GetClassificationDishes()
        {
            return await db.ClassificationDish.ToListAsync();
        }

        //Crear una clasificacion de plato
        public async Task<ClassificationDish> CreateClassificationDish(ClassificationDish classificationDish)
        {
            db.ClassificationDish.Add(classificationDish);
            await db.SaveChangesAsync();
            return classificationDish;
        }

        //Actualizar una clasificacion de plato

        public async Task<ClassificationDish> UpdateClassificationDish(ClassificationDish classificationDish)
        {
           db.Entry(classificationDish).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return classificationDish;
        }

        //Eliminar una clasificacion de plato
        public async Task<ClassificationDish?> DeleteClassificationDish(int id)
        {
            ClassificationDish? classificationDish = await db.ClassificationDish.FindAsync(id);
            if (classificationDish == null) return classificationDish;
            classificationDish.IsDeleted = false;
            db.Entry(classificationDish).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return classificationDish;

        }
    }
}
