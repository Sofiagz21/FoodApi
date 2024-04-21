using FoodApi.Context;
using FoodApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Repositories
{

    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetails();
        Task<OrderDetail?> GetOrderDetail(int id);
        Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail?> DeleteOrderDetail(int id);
    }
    public class OrderDetailRepository(ApplicationDbContext db): IOrderDetailRepository
    {
        //Obtener todos los detalles de orden
        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            return await db.OrderDetail.ToListAsync();
        }

        //Obtener un detalle de orden
        public async Task<OrderDetail?> GetOrderDetail(int id)
        {
            return await db.OrderDetail.FindAsync(id);
        }

        //Crear un detalle de orden
        public async Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail)
        {
            db.OrderDetail.Add(orderDetail);
            await db.SaveChangesAsync();
            return orderDetail;
        }

        //Actualizar un detalle de orden
        public async Task<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail)
        {
            db.Entry(orderDetail).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return orderDetail;
        }

        //Eliminar un detalle de orden
        public async Task<OrderDetail?> DeleteOrderDetail(int id)
        {
            OrderDetail? orderDetail = await db.OrderDetail.FindAsync(id);
            if (orderDetail == null) return orderDetail;
            orderDetail.IsDeleted = false;
            db.Entry(orderDetail).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return orderDetail;
        }
    }
}
