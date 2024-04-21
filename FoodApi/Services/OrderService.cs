using FoodApi.Model;
using FoodApi.Repositories;

namespace FoodApi.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrder(int id);
        Task<Order> CreateOrder(
           int IdCustomer,
           DateTime OrderDate,
           decimal OrderTotal                      
         );

        Task<Order> UpdateOrder(
          int IdOrder,
          int? IdCustomer,
          DateTime? OrderDate,
          decimal? OrderTotal
         );
        Task<Order?> DeleteOrder(int id);
    }


    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {

        //Obtener todos los pedidos
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await orderRepository.GetOrders();
        }

        //Obtener un pedido
        public async Task<Order?> GetOrder(int id)
        {
            return await orderRepository.GetOrder(id);
        }

        //Crear un pedido

        public async Task<Order> CreateOrder(
           int IdCustomer,
           DateTime OrderDate,
           decimal OrderTotal
        )
        {
            return await orderRepository.CreateOrder(new Order
            {
                IdCustomer = IdCustomer,
                OrderDate = OrderDate,
                OrderTotal = OrderTotal
            });
        }

        //Actualizar un pedido
        public async Task<Order> UpdateOrder(
           int IdOrder,
           int? IdCustomer,
           DateTime? OrderDate,
           decimal? OrderTotal
        )
        {
            Order? order = await orderRepository.GetOrder(IdOrder);
            if (order == null) throw new Exception("El pedido no existe");
            order.IdCustomer = IdCustomer?? order.IdCustomer;
            order.OrderDate = OrderDate?? order.OrderDate;
            order.OrderTotal = OrderTotal?? order.OrderTotal;
            return await orderRepository.UpdateOrder(order);
        }

        //Eliminar un pedido
        public async Task<Order?> DeleteOrder(int id)
        {
            return await orderRepository.DeleteOrder(id);
        }

        
    }
}
