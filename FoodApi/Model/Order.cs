using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodApi.Model
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; } //Id del pedido
        public required DateTime OrderDate { get; set; }
        public required decimal OrderTotal { get; set; }

        [ForeignKey(nameof(Customer))]
        public int IdCustomer { get; set; } //Id del cliente
        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;


        public virtual Customer? Customer { get; set; }
    }
}

