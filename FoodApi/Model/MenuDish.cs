using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodApi.Model
{
    public class MenuDish
    {

        [Key]
        public int IdMenuDish { get; set; }

        [ForeignKey(nameof(Menu))]
        public int IdMenu { get; set; }
        [ForeignKey(nameof(Dish))]
        public int IdDish { get; set; }
        public required string Availability { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;


        public virtual Menu? Menu { get; set; }
        public virtual Dish? Dish { get; set; }

        
    }
}

