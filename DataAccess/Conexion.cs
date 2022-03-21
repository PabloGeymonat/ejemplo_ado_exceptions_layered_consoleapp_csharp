using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess
{
	public class Conexion: IConexion
	{
		private string cadenaConexion =
			@"SERVER=LAPTOP-CU5370KK\SQLEXPRESS;
				Database=ejemplop3; 
				INTEGRATED SECURITY = TRUE;";


		public Conexion() 
		{
			
		}


		public IDbConnection CrearConexion()
		{
			SqlConnection connection = new SqlConnection(cadenaConexion);
			
			return connection;
		}

		
		public bool AbrirConexion(IDbConnection cn)
		{
			if (cn == null)
				return false;
			if (cn.State != ConnectionState.Open)
			{
				cn.Open();
				return true;
			}
			return false;
		}


		public bool CerrarConexion(IDbConnection cn)
		{
			if (cn == null)
				return false;
			if (cn.State != ConnectionState.Closed)
			{
				cn.Close();
				cn.Dispose();//liberar los recursos "tomados" por la conexión
				return true;
			}
			return false;
		}
	}
}
