using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodApi.Model
{
    public class Customer
    {

        [Key]
        public int IdCustomer { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerLastName { get; set; }
        public required string CustomerPhone { get; set; }
        public required string CustomerAdress { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;
    }
}

