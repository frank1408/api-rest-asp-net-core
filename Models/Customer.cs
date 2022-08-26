using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoApi.Models
{
	public class Customer
	{

		public int? Id { get; set; }

		[Required(ErrorMessage = "DEBE ESPECIFICARSE EL NOMBRE!")]
		public string? Nombre { get; set; }

		[Required(ErrorMessage = "DEBE ESPECIFICARSE EL APELLIDO!")]
		public string? Apellido { get; set; }

		[Required(ErrorMessage = "DEBE ESPECIFICARSE EL CORREO!")]
		public string? Correo { get; set; }

		[Required(ErrorMessage = "DEBE ESPECIFICARSE EL TELEFONO!")]
		public string? Telefono { get; set; }

		[Required(ErrorMessage = "DEBE ESPECIFICARSE LA DIRECCION!")]
		public string? Direccion { get; set; }
	}
}

