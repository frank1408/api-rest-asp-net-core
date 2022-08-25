using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoPizza.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PizzaController : ControllerBase
	{
		// GET: /<controller>/
		public PizzaController()
		{
		} // constructor




		// http method GET all action
		[Microsoft.AspNetCore.Mvc.HttpGet]
		// Return Respuesta 200 Http OK
		[ProducesResponseType(StatusCodes.Status200Ok, Type=typeof(Pizza) )]
		// Return Respuesta 404 Http NotFound
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public Microsoft.AspNetCore.Mvc.ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
		//public async Task<IActionResult> GetPizzas() => throw new NotImplementedException();
		// get || read




		// http method GET by Id action
		[Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
		// Return Respuesta 200 Http OK
		[ProducesResponseType(StatusCodes.Status200Ok, Type=typeof(Pizza) )]
		// Return Respuesta 404 Http NotFound
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public Microsoft.AspNetCore.Mvc.ActionResult<Pizza> Get(int id)
		//public async Task<IActionResult> GetPizza(int id)
		{
			var pizza = PizzaService.Get(id);
			if (pizza is null)
			{
				// error 404
				return this.NotFound();
			}
			// var vacio = new Pizza();
			// return new OkObjectResult( vacio );
			return pizza;
		} // get || read





		// http method POST action
		[Microsoft.AspNetCore.Mvc.HttpPost]
		// Return Respuesta 201 Http OK
		[ProducesResponseType(StatusCodes.Status201Created, Type=typeof(Pizza) )]
		// Return Respuesta 404 Http NotFound
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public Microsoft.AspNetCore.Mvc.IActionResult Create(Pizza pizza)
		{
			ContosoPizza.Services.PizzaService.Add(pizza);
			return this.CreatedAtAction( nameof(this.Create), new { id = pizza.Id }, pizza );
			// var vacio = new Pizza();
			// return new CreatedResult($"dominio/api/pizza/{vacio.Id}", null);
		} // Post || Create





		// http method PUT action
		[Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
		// Return Respuesta 200 Http OK
		[ProducesResponseType(StatusCodes.Status200Ok, Type=typeof(bool) )]
		public Microsoft.AspNetCore.Mvc.IActionResult Update(int id, Pizza pizza)
		{
			if ( id != pizza.Id )
			{
				return this.BadRequest();
			}

			var existingPizza = ContosoPizza.Services.PizzaService.Get(id);

			if (existingPizza is null)
			{
				return this.NotFound();
			}

			ContosoPizza.Services.PizzaService.Update(pizza);

			return this.NoContent();
		} // Update 







		// http method DELETE action
		[Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
		// Return Respuesta 200 Http OK
		[ProducesResponseType(StatusCodes.Status200Ok, Type=typeof(bool) )]
		public Microsoft.AspNetCore.Mvc.IActionResult Delete(int id)
		{
			var pizza = ContosoPizza.Services.PizzaService.Get(id);

			if ( pizza is null )
			{
				return this.NotFound();
			}

			ContosoPizza.Services.PizzaService.Delete(id);

			return this.NoContent();
			// return new NotImplementedException();
		} // Delete







/*
Microsoft.AspNetCore.Mvc.ActionResult
ActionResult
o
IActionResult ?

*/



	} // class PizzaController : ControllerBase
}
