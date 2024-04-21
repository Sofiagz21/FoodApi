using FoodApi.Context;
using FoodApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrder(int id);
        Task<Order> CreateOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<Order?> DeleteOrder(int id);
    }
    public class OrderRepository(ApplicationDbContext db): IOrderRepository
    {
        //Obtener todos los pedidos
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await db.Order.ToListAsync();
        }

        //Obtener un pedido
        public async Task<Order?> GetOrder(int id)
        {
            return await db.Order.FindAsync(id);
        }

        //Crear un pedido
        public async Task<Order> CreateOrder(Order order)
        {
            db.Order.Add(order);
            await db.SaveChangesAsync();
            return order;
        }

        //Actualizar un pedido
        public async Task<Order> UpdateOrder(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return order;
        }

        //Eliminar un pedido
        public async Task<Order?> DeleteOrder(int id)
        {
            Order? order = await db.Order.FindAsync(id);
            if (order == null) return order;
            order.IsDeleted = false;
            db.Entry(order).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return order;
        }
    }
}
