using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

using ProyectoApi.Models;
using ProyectoApi.Repositories;
using ProyectoAPI.Services;

namespace ProyectoApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{
		//private CustomerService _customerService;
		private ICustomerContext _customerContext;






		public CustomerController(ICustomerContext customerContext )
		{
			//_customerService = customerService;
			_customerContext = customerContext;
		}
















		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetCustomers()
		{
			List<Customer> tmpResponse = await _customerContext.ReadCustomers();
			if (tmpResponse is null)
			{
				return new NotFoundResult();
			}
			return new OkObjectResult(tmpResponse);
		}

















		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetCustomer(int id)
		{
			Customer? tmpResponse = await _customerContext.ReadCustomer(id);
			if (tmpResponse is null)
			{
				return new NotFoundResult();
			}
			return new OkObjectResult(tmpResponse);
		}

















		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customer))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> PostCustomer( Customer customer)
		{
			Customer? tmpResponse = await _customerContext.CreateCustomer( customer );
			if (tmpResponse is null)
			{
				return new NotFoundResult();
			}
			return new CreatedResult($"https://localhost:1234/api/customer/{tmpResponse.Id}", null );

		}











		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
		//[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> PutCustomer(int id, Customer tmpCustomer)
		{
			//Customer? resultado = await _customerContext.UpdateCustomer(tmpCustomer);
			await _customerContext.UpdateCustomer(tmpCustomer);

			//if ( resultado is null )
			//{
			//	return new NotFoundResult();
			//}
			return new OkObjectResult(tmpCustomer);
		}














		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
		//[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			bool resultado = await _customerContext.DeleteCustomer(id);
			if ( resultado == false )
			{
				return new NotFoundResult();
			}
			return new OkObjectResult(resultado);
		}



















	}
}
