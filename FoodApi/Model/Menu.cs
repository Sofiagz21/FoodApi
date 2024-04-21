using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodApi.Model
{
    public class Menu
    {
        [Key]
        public  int IdMenu {get; set;}
        public required string MenuName { get; set;}
        public required string MenuDescription { get; set;}

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

    }
}
