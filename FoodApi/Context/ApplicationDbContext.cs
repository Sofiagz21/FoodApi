using FoodApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<ClassificationDish> ClassificationDish { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuDish> MenuDish { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClassificationDish>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<Dish>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<Menu>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<MenuDish>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<OrderDetail>().HasQueryFilter(p => p.IsDeleted);
            modelBuilder.Entity<Customer>().HasQueryFilter(p => p.IsDeleted);


            //modelBuilder.Entity<Orders>()
            //.HasOne(p => p.Customer)
            //.WithMany(u => u.Order) //Indicia que un cliente puede tener muchos pedidos
            //.HasForeignKey(p => p.IdCustomer) //Indica que la clave foranea es IdCustomer
            //.OnDelete(DeleteBehavior.Restrict); //Indica que si se elimina un cliente se eliminan todos los pedidos asociados a el

        }

       

    }
}
