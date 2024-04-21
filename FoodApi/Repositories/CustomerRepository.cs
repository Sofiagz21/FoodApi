using FoodApi.Context;
using FoodApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomer(int id);
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer?> DeleteCustomer(int id);
    }
    public class CustomerRepository(ApplicationDbContext db): ICustomerRepository
    {

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await db.Customer.ToListAsync();
        }

        public async Task<Customer?> GetCustomer(int id)
        {
            return await db.Customer.FindAsync(id);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            db.Customer.Add(customer);
            await db.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteCustomer(int id)
        {
            Customer? customer = await db.Customer.FindAsync(id);
            if (customer == null) return null;
            customer.IsDeleted = false;
            db.Entry(customer).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return customer;
        }

    }
}
