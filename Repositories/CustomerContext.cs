using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Org.BouncyCastle.Tls.Crypto;
using ProyectoApi.Models;


namespace ProyectoApi.Repositories
{

	public interface ICustomerContext
	{
		Task<List<Customer>> ReadCustomers();
		Task<bool> DeleteCustomer(long id);
		Task<Customer> ReadCustomer(long id);
		Task<Customer> CreateCustomer(Customer tmpCustomer);
		Task<bool> UpdateCustomer(Customer tmpCustomer);
	}

	public class CustomerContext : DbContext, ICustomerContext
	{
		// Table: "Customer";
		private DbSet<Customer> Customer { get; set; }


		public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
		{
		}


		public async Task<Customer?> ReadCustomer(long id)
		{
			// get 1
			return await this.Customer.FirstOrDefaultAsync(tmpCustomer => tmpCustomer.Id == id);
			// OK return await this.Customer.FirstAsync(tmpCustomer => tmpCustomer.Id == id);
		}





		public async Task<Customer?> CreateCustomer(Customer tmpCustomer)
		{
			// post
			EntityEntry<Customer> response = await Customer.AddAsync(tmpCustomer);

			await this.SaveChangesAsync();

			return await ReadCustomer(response.Entity.Id ?? throw new Exception("No se pudo guardar en DB"));

		}









		public async Task<List<Customer>> ReadCustomers()
		{
			// get all
			return await this.Customer.ToListAsync();
		}









		public async Task<bool> DeleteCustomer(long id)
		{
			// delete
			Customer tmpCustomer = await this.Customer.FirstAsync(findCustomer => findCustomer.Id == id);
			if (tmpCustomer is null)
			{
				return false;
			}
			this.Customer.Remove(tmpCustomer);
			SaveChanges();
			return true;
		}








		public async Task<bool> UpdateCustomer(Customer updatedCustomer)
		{
			// update
			this.Customer.Update(updatedCustomer);
			await SaveChangesAsync();
			return true;
		}


















	}
}
