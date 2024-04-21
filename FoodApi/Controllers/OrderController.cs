using FoodApi.Model;
using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            IEnumerable<Order> orders = await orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            Order? order = await orderService.GetOrder(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(
           int IdCustomer,
           DateTime OrderDate,
           decimal OrderTotal
         )
        {
            var order = await orderService.CreateOrder( IdCustomer,OrderDate, OrderTotal);
            return CreatedAtAction(nameof(GetOrder), new { id = order.IdOrder }, order);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(
           int IdOrder,
           int? IdCustomer,
           DateTime? OrderDate,
           decimal? OrderTotal
        )
        {
            var updatedOrder = await orderService.UpdateOrder(IdOrder, IdCustomer, OrderDate, OrderTotal);
            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await orderService.DeleteOrder(id);
            if (order == null) return NotFound();
            return Ok(order);
        }
    }
}
