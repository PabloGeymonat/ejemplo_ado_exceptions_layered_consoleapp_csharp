using System;
using Domain.Exceptions;

namespace Domain
{
	public class Categoria { 
		public int Id { get; set; }

		public string Nombre { get; set; }

		public string Descripcion { get; set; }


		public void Copiar(Categoria unaCategoria) 
		{
			this.Nombre = unaCategoria.Nombre;
			this.Descripcion = unaCategoria.Descripcion;
		}

		public override string ToString()
		{
			return $"{Id} - {Nombre} - {Descripcion}";
		}


		private void ThrowExceptionSiAtributoEsNull(string valor, string mensaje)
		{
			if (valor == null)
			{
				throw new ElementoInvalidoException(mensaje);
			}
		}
	

		public bool Validar()
		{
			// retorna una excepcion si no valida
			// motivo: no solo debo saber que NO valida, si no el POR QUE...basado en Clean Code de Robert Martin
			ThrowExceptionSiAtributoEsNull(this.Nombre, "El nombre de la categoría no puede ser nulo");
			ThrowExceptionSiAtributoEsNull(this.Descripcion, "El nombre de la categoría no puede ser nulo");
			return true;
		}

	}
}
