using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodApi.Model
{
    public class ClassificationDish
    {
        [Key]
        public int IdClassificationDish { get; set; }
        public required string ClassificationDishName { get; set; }
        public required string ClassificationDishDescription { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;
    }
}
