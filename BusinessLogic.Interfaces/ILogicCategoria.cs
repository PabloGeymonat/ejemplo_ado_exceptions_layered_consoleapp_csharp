using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface ILogicCategoria
    {

        Categoria CrearCategoria(Categoria unaCategoria);

        Categoria ObtenerUnaCategoria(int id);

        IEnumerable<Categoria> ObtenerCategorias();

        void EliminarCategoria(int id);

        Categoria ActualizarCategoria(int id, Categoria unaCategoria);

        
        
    }
}
