using BusinessLogic.Interfaces;
using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace presentacion
{
    public class ControladorDeCategorias
    {

        private ILogicCategoria _logicCategoria;
        public ControladorDeCategorias(ILogicCategoria logicCategoria) 
        {
            this._logicCategoria = logicCategoria;
        }

        public void PruebaListarCategorias()
        {
            IEnumerable categorias = _logicCategoria.ObtenerCategorias();
            foreach (Categoria cat in categorias)
            {
                Console.WriteLine(cat.ToString());
            }
        }


        public void PruebaObtenerUnaCategoria()
        {
            Categoria categoria = _logicCategoria.ObtenerUnaCategoria(1);                        
            Console.WriteLine(categoria.ToString());            
        }


        public void PruebaCrearCategoria()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "La Categoria",
                Descripcion = "Descripcion de la categoria"
            };
            Categoria cat = this._logicCategoria.CrearCategoria(categoria);

            Console.WriteLine("La nueva cat es: " + cat.ToString());

        }


        public void PruebaModificarCategoria()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "La Categoria modificada",
                Descripcion = "Descripcion de la categoria modificada"
            };
            this._logicCategoria.ActualizarCategoria(1, categoria);
        }

    }
}
