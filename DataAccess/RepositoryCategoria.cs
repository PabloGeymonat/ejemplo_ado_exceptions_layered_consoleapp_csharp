using DataAccess.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Interfaces.Exceptions;

namespace DataAccess
{
	public class RepositoryCategoria : IRepositoryCategoria
	{
		

		private IDbConnection cn;
		public RepositoryCategoria(IDbConnection cn) 
		{
			this.cn = cn;	
		}


		public Categoria Add(Categoria unaCategoria)
		{
			ThrowExceptionSiConexionNula();
			ThrowExceptionSiCategoriaNula(unaCategoria);

			//Preparar el comando
			IDbCommand cmd = new SqlCommand();
			cmd.CommandText = @"INSERT INTO Categoria (Nombre,Descripcion) 
									VALUES (@nom, @desc)";
			//Agregarle los parámetros al comando
			cmd.Parameters.Add(new SqlParameter("@nom", unaCategoria.Nombre));
			cmd.Parameters.Add(new SqlParameter("@desc", unaCategoria.Descripcion));

			cmd.Connection = this.cn as SqlConnection;
			try
			{
				int filasAfectadas = cmd.ExecuteNonQuery();
				if (filasAfectadas == 1)
					return unaCategoria;

			}
			catch (Exception e)
			{
				throw new RepositoryException(e.Message);
			}
							
			return null;
		}

		private void ThrowExceptionSiConexionNula() 
		{
			if (this.cn == null)
			{
				throw new Exception("La conexión no puede ser nula");
			}
		}

		private void ThrowExceptionSiCategoriaNula(Categoria unaCategoria) 
		{
			if (unaCategoria == null)
			{
				throw new Exception("La categoría no puede ser nula");
			}

		}


		public List<Categoria> FindAll()
		{

			ThrowExceptionSiConexionNula();

			List<Categoria> listaCategorias = new List<Categoria>();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "SELECT * FROM Categoria";
			cmd.Connection = cn as SqlConnection;			
			try
			{
				SqlDataReader filas = cmd.ExecuteReader();
				while (filas.Read())
				{
					listaCategorias.Add(new Categoria
					{
						Id = (int)filas["Id"],
						Nombre = filas["Nombre"].ToString(),
						Descripcion = filas["Descripcion"].ToString()
					});
				}
				filas.Close();
				return listaCategorias;
			}
			catch (Exception e)
			{
				throw new RepositoryException(e.Message);
			}
		}


		public Categoria FindById(int id)
		{
			ThrowExceptionSiConexionNula();
			Categoria categoria = null;
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "SELECT * FROM Categoria WHERE Id = @id";
			cmd.Parameters.Add(new SqlParameter("@id", id));
			cmd.Connection = this.cn as SqlConnection;
			try
			{
				SqlDataReader filas = cmd.ExecuteReader();
				if (filas.Read())
				{
					categoria = new Categoria
					{
						Id = (int)filas["Id"],
						Nombre = filas["Nombre"].ToString(),
						Descripcion = filas["Descripcion"].ToString()
					};
				}
				filas.Close();
				return categoria;
			}
			catch (Exception e)
			{
				throw new RepositoryException(e.Message);
			}
		}


		public Categoria FindByName(string nombre)
		{
			ThrowExceptionSiConexionNula();

			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "SELECT * FROM Categoria WHERE Nombre=@nombre";
			cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
			cmd.Connection = this.cn  as SqlConnection;
			Categoria categoria = null;
			try
			{
				SqlDataReader filas = cmd.ExecuteReader();
				while (filas.Read())
				{
					categoria = new Categoria
					{
						Id = (int)filas["Id"],
						Nombre = filas["Nombre"].ToString(),
						Descripcion = filas["Descripcion"].ToString()
					};
				}
				filas.Close();
				return categoria;
			}
			catch (Exception e)
			{
				throw new RepositoryException(e.Message);
			}
		}

		public List<Categoria> FindSimilares(string texto)
		{
			ThrowExceptionSiConexionNula();

			List<Categoria> listaCategorias = new List<Categoria>();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "SELECT * FROM Categoria WHERE Nombre LIKE '%' + @nombre+ '%'";
			cmd.Parameters.Add(new SqlParameter("@nombre", texto));
			cmd.Connection = this.cn as SqlConnection;
			try
			{
				SqlDataReader filas = cmd.ExecuteReader();
				while (filas.Read())
				{
					listaCategorias.Add(new Categoria
					{
						Id = (int)filas["Id"],
						Nombre = filas["Nombre"].ToString(),
						Descripcion = filas["Descripcion"].ToString()
					});
				}
				filas.Close();
				return listaCategorias;
			}
			catch (Exception e)
			{
				throw new RepositoryException(e.Message);
			}
		}

		public bool Remove(int CodigoCategoria)
		{
			IDbCommand cmd = new SqlCommand();
			cmd.CommandText = @"DELETE FROM Categoria WHERE Id=@id";
			cmd.Parameters.Add(new SqlParameter("@id", CodigoCategoria));
			cmd.Connection = this.cn as SqlConnection;
            try 
			{
				int filasAfectadas = cmd.ExecuteNonQuery();
				if (filasAfectadas == 1)
				{
					return true;
				}
				return false;
			}
			catch (Exception e)
			{
				throw new RepositoryException(e.Message);
			}
			
		}

		public bool Remove(Categoria unaCategoria)
		{	
			ThrowExceptionSiCategoriaNula(unaCategoria);
			try
			{
				return Remove(unaCategoria.Id);
			}
			catch (Exception e)
			{
				throw new RepositoryException(e.Message);
			}			
		}

		public Categoria Update(Categoria unaCategoria)
		{
			ThrowExceptionSiConexionNula();
			ThrowExceptionSiCategoriaNula(unaCategoria);
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "UPDATE Categoria SET nombre=@nombre, descripcion=@desc WHERE id=@id";
			cmd.Connection = this.cn as SqlConnection;
			cmd.Parameters.Add(new SqlParameter("@nombre", unaCategoria.Nombre));
			cmd.Parameters.Add(new SqlParameter("@desc", unaCategoria.Descripcion));
			cmd.Parameters.Add(new SqlParameter("@id", unaCategoria.Id));
			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception e) {
				throw new RepositoryException(e.Message);
			}

			return unaCategoria;
		}

		public int ContarCategorias()
		{
			ThrowExceptionSiConexionNula();		

			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "SELECT COUNT (*) FROM Categoria";
			cmd.Connection = this.cn as SqlConnection;
			int cantFilas = 0;
			try {
				cantFilas = (int)cmd.ExecuteScalar();
			}
			catch (Exception e) {
				throw new RepositoryException(e.Message);
			}	
			return cantFilas;			
			
		}
	}
}
