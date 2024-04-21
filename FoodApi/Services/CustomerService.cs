using FoodApi.Model;
using FoodApi.Repositories;

namespace FoodApi.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomer(int id);
        Task<Customer> CreateCustomer(
            string CustomerName,
            string CustomerLastName,
            string CustomerPhone,
            string CustomerAdress
      );
        Task<Customer> UpdateCustomer(
         int IdCustomer,
         string? CustomerName,
         string? CustomerLastName,
         string? CustomerPhone,
         string? CustomerAdress
                   );
        Task<Customer?> DeleteCustomer(int id);
    }
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await customerRepository.GetCustomers();
        }

        public async Task<Customer?> GetCustomer(int id)
        {
            return await customerRepository.GetCustomer(id);
        }

        public async Task<Customer> CreateCustomer(
           string CustomerName,
           string CustomerLastName,
           string CustomerPhone,
           string CustomerAdress
         )
        {
            Customer customer = new Customer
            {
                CustomerName = CustomerName,
                CustomerLastName = CustomerLastName,
                CustomerPhone = CustomerPhone,
                CustomerAdress = CustomerAdress
            };
            return await customerRepository.CreateCustomer(customer);
        }

        public async Task<Customer> UpdateCustomer(
           int IdCustomer,
           string? CustomerName,
           string? CustomerLastName,
           string? CustomerPhone,
           string? CustomerAdress
         )
        {
            Customer? customer = await customerRepository.GetCustomer(IdCustomer);
            if (customer == null) throw new Exception("Customer not found");
            if (CustomerName != null) customer.CustomerName = CustomerName;
            if (CustomerLastName != null) customer.CustomerLastName = CustomerLastName;
            if (CustomerPhone != null) customer.CustomerPhone = CustomerPhone;
            if (CustomerAdress != null) customer.CustomerAdress = CustomerAdress;
            return await customerRepository.UpdateCustomer(customer);
        }

        public async Task<Customer?> DeleteCustomer(int id)
        {
            return await customerRepository.DeleteCustomer(id);
        }
    }
}
