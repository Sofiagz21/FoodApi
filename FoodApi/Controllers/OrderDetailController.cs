using FoodApi.Model;
using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController(IOrderDetailService orderDetailService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            IEnumerable<OrderDetail> orderDetails = await orderDetailService.GetOrderDetails();
            return Ok(orderDetails);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            OrderDetail? orderDetail = await orderDetailService.GetOrderDetail(id);
            if (orderDetail == null) return NotFound();
            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(
            int IdOrder,
            int IdDish,
            int Amount
         )
        {
            var orderDetail = await orderDetailService.CreateOrderDetail(IdOrder, IdDish, Amount);
            return CreatedAtAction(nameof(GetOrderDetail), new { id = orderDetail.IdOrderDetail }, orderDetail);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(
           int IdOrderDetail,
           int? IdOrder,
           int? IdDish,
           int Amount
         )
        {
            var updatedOrderDetail = await orderDetailService.UpdateOrderDetail(IdOrderDetail, IdOrder, IdDish, Amount);
            return Ok(updatedOrderDetail);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var deletedOrderDetail = await orderDetailService.DeleteOrderDetail(id);
            if (deletedOrderDetail == null) return NotFound();
            return Ok(deletedOrderDetail);
        }
    }
}
