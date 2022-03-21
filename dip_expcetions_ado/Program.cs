using System;
using System.Data;
using System.Data.SqlClient;

using DataAccess;
using businessLogic;
using Domain;

using BusinessLogic.Interfaces;
using System.Collections;
using presentacion;

namespace dip_expcetions_ado
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("iniciando.....");

            /*  
                esta parte debe realizarse por inyeccion de dependencia 
                en el proximo ejemplo con services (startup), por otra parte
                este ejemplo muestra como hacerlo 'manualmente'
             
            */

            /* 1 - crea la conexion */
            Conexion conexion = new Conexion();
            IDbConnection cn = conexion.CrearConexion();

            /* 2 - abre la conexion */
            conexion.AbrirConexion(cn);

            /* 3 - inyecta la conexion al repo*/
            RepositoryCategoria repo = new RepositoryCategoria(cn); 
            
            /* 4 - inyecta el repo a la logica*/
            CategoriaLogic categoriaLogic = new CategoriaLogic(repo);

            /********************************************************************************/
            /*
            |===========================================================|
            |                                                           |
            |                         presentacion                      |
            |                                                           |
            |===========================================================|
                                        |
                                        |
                                        \/
            |===========================================================|
            |                                                           |
            |                  businessLogic.interfaces                 |
            |                                                           |
            |===========================================================|
                                        /\
                                        |
                                        |                                        
            |===========================================================|
            |                                                           |
            |                      businessLogic                        |
            |                                                           |
            |===========================================================|
                                        |
                                        |
                                        \/
            |===========================================================|
            |                                                           |
            |                     DataAccess.Interfaces                |
            |                                                           |
            |===========================================================|                            |
                                        /\
                                        |
                                        |
            |===========================================================|
            |                                                           |
            |                      DataAccess                           |
            |                                                           |
            |===========================================================|

            Aplica: 
            *   Layered Architecture (nota las fechas indican la dependencias entre capas, 
            *       una capa concreta solo depende de abstracciones(interfaces))
            *   Inversion de dependencias (DIP)
            *   Inyeccion de dependencias (DI)
            *   Repository(entre capas DataAccess.Interfaces y DataAccess)
            *      
            */


            try
            {
                //inyecta la logica al controlador
                ControladorDeCategorias controlador = new ControladorDeCategorias(categoriaLogic);
                controlador.PruebaCrearCategoria();       
                controlador.PruebaModificarCategoria();   //siempre modifica la categoría con id=1
                controlador.PruebaListarCategorias();
                controlador.PruebaObtenerUnaCategoria();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conexion.CerrarConexion(cn);
                Console.ReadLine();
            }

        }




    }
}
