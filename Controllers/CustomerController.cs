using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

using ProyectoApi.Models;
using ProyectoApi.Repositories;

// https://www.youtube.com/watch?v=CELr1qGkkUI
// validaciones seguridad api rest .net core

// json web token
// https://www.youtube.com/watch?v=3NJbzf-41f0

// https://www.youtube.com/watch?v=LaXmyHsXfYo
// 3:10:29 consumir api con JS

namespace ProyectoApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[EnableCors]
	public class CustomerController : ControllerBase
	{
		private ICustomerContext _customerContext;






		public CustomerController(ICustomerContext customerContext )
		{
			_customerContext = customerContext;
		}
















		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		//[EnableCors(origins: "*", headers: "*", methods: "*")]
		//[EnableCors]
		//[DisableCors]
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
		public async Task<IActionResult> PostCustomer( Customer customer)
		{
			Customer? tmpResponse = await _customerContext.CreateCustomer( customer );
			if (tmpResponse is null)
			{
				return new NotFoundResult();
			}
			return new CreatedResult("", null);
		}











		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> PutCustomer(int id, Customer tmpCustomer)
		{
			Customer? existe = await _customerContext.ReadCustomer(id);
			if( existe != null )
			{
				await _customerContext.UpdateCustomer(tmpCustomer);
				return new OkObjectResult(tmpCustomer);
			}
			return new BadRequestResult();
		}














		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			Customer? existe = await _customerContext.ReadCustomer(id);
			if (existe != null)
			{
				bool resultado = await _customerContext.DeleteCustomer(id);

				if (resultado)
				{
					return new OkObjectResult(resultado);
				}
				return new NotFoundResult(); // no se pudo eliminar aunque existe
			}

			// no existe
			return new NotFoundResult();
		}



















	}
}
