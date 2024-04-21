using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodApi.Model
{
    public class Dish
    {
        [Key]
        public int IdDish {  get; set; }
        public required string DishName { get; set; }
        public required string DishDescription { get; set; }
        public required int DishAvaliability { get; set; }
        public required string DishPrice { get; set; }

        [ForeignKey(nameof(ClassificationDish))]
        public int IdClassificationDish { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;


        public virtual ClassificationDish? ClassificationDish { get; set; }
    }
}

