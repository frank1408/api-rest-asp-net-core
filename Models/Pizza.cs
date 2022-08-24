using System;

namespace ContosoPizza.Models
{
	public class Pizza
	{
		public Pizza()
		{
		} // constructor



		public int Id { get; set; }
		[Required (ErrorMessage	="DEBE ESPECIFICARSE EL NOMBRE!")]
		public string? Name { get; set; }
		[Required (ErrorMessage	="DEBE ESPECIFICARSE SI ES LIBRE DE GLUTEN!")]
		public bool IsGlutenFree { get; set; }













	} // class
} // namespace

