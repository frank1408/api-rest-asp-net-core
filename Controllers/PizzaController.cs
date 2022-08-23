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
		public Microsoft.AspNetCore.Mvc.ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
		// get || read




		// http method GET by Id action
		[Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
		public Microsoft.AspNetCore.Mvc.ActionResult<Pizza> Get(int id)
		{
			var pizza = PizzaService.Get(id);
			if (pizza is null)
			{
				// error 404
				return this.NotFound();
			}
			return pizza;
		} // get || read





		// http method POST action
		[Microsoft.AspNetCore.Mvc.HttpPost]
		public Microsoft.AspNetCore.Mvc.IActionResult Create(Pizza pizza)
		{
			ContosoPizza.Services.PizzaService.Add(pizza);
			return this.CreatedAtAction( nameof(this.Create), new { id = pizza.Id }, pizza );
		} // Post || Create





		// http method PUT action
		[Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
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
		public Microsoft.AspNetCore.Mvc.IActionResult Delete(int id)
		{
			var pizza = ContosoPizza.Services.PizzaService.Get(id);

			if ( pizza is null )
			{
				return this.NotFound();
			}

			ContosoPizza.Services.PizzaService.Delete(id);

			return this.NoContent();
		} // Delete




	} // class PizzaController : ControllerBase
}
