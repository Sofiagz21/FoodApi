using FoodApi.Model;
using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            IEnumerable<Customer> customers = await customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            Customer? customer = await customerService.GetCustomer(id);
            if (customer == null)return NotFound();
            return Ok(customer);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer(
            string CustomerName,
            string CustomerLastName,
            string CustomerPhone,
            string CustomerAdress
        )
        {
            var customer = await customerService.CreateCustomer(CustomerName, CustomerLastName, CustomerPhone, CustomerAdress);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.IdCustomer }, customer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(
            int IdCustomer,
            string? CustomerName,
            string? CustomerLastName,
            string? CustomerPhone,
            string? CustomerAdress
         )
        {
            var updateCustomer = await customerService.UpdateCustomer(IdCustomer, CustomerName, CustomerLastName, CustomerPhone, CustomerAdress);
            return Ok(updateCustomer);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleteCustomer = await customerService.DeleteCustomer(id);
            if (deleteCustomer == null) return NotFound();
            return Ok(deleteCustomer);

        }
    }
}
