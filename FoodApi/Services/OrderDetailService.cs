using FoodApi.Model;
using FoodApi.Repositories;

namespace FoodApi.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetails();
        Task<OrderDetail?> GetOrderDetail(int id);
        Task<OrderDetail> CreateOrderDetail(
          int IdOrder,
          int IdDish,
          int Amount
         );
        Task<OrderDetail> UpdateOrderDetail(
          int IdOrderDetail,
          int? IdOrder,
          int? IdDish,
          int? Amount
        );
        Task<OrderDetail?> DeleteOrderDetail(int id);
    }
    public class OrderDetailService(IOrderDetailRepository orderDetailRepository) : IOrderDetailService
    {
        //Obtener todos los detalles de orden
        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            return await orderDetailRepository.GetOrderDetails();
        }

        //Obtener un detalle de orden
        public async Task<OrderDetail?> GetOrderDetail(int id)
        {
            return await orderDetailRepository.GetOrderDetail(id);
        }

        //Crear un detalle de orden

        public async Task<OrderDetail> CreateOrderDetail(
           int IdOrder,
           int IdDish,
           int Amount
          )
        {
            return await orderDetailRepository.CreateOrderDetail(new OrderDetail
            {
                IdOrder = IdOrder,
                IdDish = IdDish,
                Amount = Amount
            });
        }

        //Actualizar un detalle de orden
        public async Task<OrderDetail> UpdateOrderDetail(
             int IdOrderDetail,
             int? IdOrder,
             int? IdDish,
             int? Amount
          )
        {
            OrderDetail? orderDetail = await orderDetailRepository.GetOrderDetail(IdOrderDetail);
            if (orderDetail == null) throw new Exception("El detalle de orden no existe");
            orderDetail.IdOrder = IdOrder ?? orderDetail.IdOrder;
            orderDetail.IdDish = IdDish ?? orderDetail.IdDish;
            orderDetail.Amount = Amount ?? orderDetail.Amount;
            return await orderDetailRepository.UpdateOrderDetail(orderDetail);
        }

        //Eliminar un detalle de orden
        public async Task<OrderDetail?> DeleteOrderDetail(int id)
        {
            return await orderDetailRepository.DeleteOrderDetail(id);
        }
    }
}
