using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IConexion
    {
		public IDbConnection CrearConexion();

		public bool AbrirConexion(IDbConnection cn);
		
		public bool CerrarConexion(IDbConnection cn);
		
	}
}
