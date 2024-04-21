using FoodApi.Model;
using FoodApi.Repositories;

namespace FoodApi.Services
{
    public interface IClassificationDishService
    {
        Task<IEnumerable<ClassificationDish>> GetClassificationDishes();
        Task<ClassificationDish?> GetClassificationDish(int id);
        Task<ClassificationDish> CreateClassificationDish(string ClassificationDishName, string ClassificationDishDescription); 
        Task<ClassificationDish> UpdateClassificationDish(int IdClassificationDish, string ClassificationDishName, string ClassificationDishDescription);
        Task<ClassificationDish?> DeleteClassificationDish(int id);
    }
    public class ClassificationDishService(IClassificationDishRepository classificationDishRepository):   IClassificationDishService
    {
        //Obtener todas las clasificaciones de platillos
        public async Task<IEnumerable<ClassificationDish>> GetClassificationDishes()
        {
            return await classificationDishRepository.GetClassificationDishes();
        }

        //Obtener una clasificacion de platillo
        public async Task<ClassificationDish?> GetClassificationDish(int id)
        {
            return await classificationDishRepository.GetClassificationDish(id);
        }

        //Crear una clasificacion de platillo

        public async Task<ClassificationDish> CreateClassificationDish(
            string ClassificationDishName,
            string ClassificationDishDescription
        )
        {
            return await classificationDishRepository.CreateClassificationDish( new ClassificationDish
            {
                ClassificationDishName = ClassificationDishName,
                ClassificationDishDescription = ClassificationDishDescription
            });
        }

        //Actualizar una clasificacion de platillo
        public async Task<ClassificationDish> UpdateClassificationDish(
           int IdClassificationDish,
           string? ClassificationDishName,
           string? ClassificationDishDescription
                   )
        {
            ClassificationDish? classificationDish = await classificationDishRepository.GetClassificationDish(IdClassificationDish);
            if (classificationDish == null) throw new Exception("La clasificación de platillo no existe");
            classificationDish.ClassificationDishName = ClassificationDishName?? classificationDish.ClassificationDishName;
            classificationDish.ClassificationDishDescription = ClassificationDishDescription?? classificationDish.ClassificationDishDescription;
            return await classificationDishRepository.UpdateClassificationDish(classificationDish);
        }

        //Eliminar una clasificacion de platillo
        public async Task<ClassificationDish?> DeleteClassificationDish(int id)
        {
            return await classificationDishRepository.DeleteClassificationDish(id);
        }
    }
}
