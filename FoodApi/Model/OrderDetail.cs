using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodApi.Model
{
    public class OrderDetail
    {
        [Key]

        public int IdOrderDetail { get; set; }

        [ForeignKey(nameof(Order))]
        public  int IdOrder { get; set; }
        [ForeignKey(nameof(Dish))]
        public int IdDish { get; set; }
        public int Amount { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual Order? Order { get; set; }
        public virtual Dish? Dish   { get; set; }

        
    }
}


