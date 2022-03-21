using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Domain;
using Domain.Exceptions;
using System;
using System.Collections.Generic;


namespace businessLogic
{

    /// <summary>
    ///  recordar que esta clase es una fachada para usar los servicios del repositorio
    /// </summary>
    public class CategoriaLogic : ILogicCategoria
    {
        private IRepositoryCategoria _repository;

        public CategoriaLogic(IRepositoryCategoria aReposotory)
        {
            _repository = aReposotory;
        }

        public Categoria CrearCategoria(Categoria unaCategoria)
        {
            ThrowExeptionSiCategoriaInvalida(unaCategoria);            
            _repository.Add(unaCategoria);            
            return unaCategoria;
        }

        public Categoria ObtenerUnaCategoria(int id)
        {
            Categoria Categoria = _repository.FindById(id);
            ThrowExceptionSiNoEncuentraLaCategoria(Categoria);
            return Categoria;
        }

        public IEnumerable<Categoria> ObtenerCategorias()
        {            
            IEnumerable<Categoria> categorias = _repository.FindAll();           
            return categorias;
        }

        public void EliminarCategoria(int id)
        {
            Categoria Categoria = _repository.FindById(id);
            ThrowExceptionSiNoEncuentraLaCategoria(Categoria);
            _repository.Remove(Categoria);            
        }

        public Categoria ActualizarCategoria(int id, Categoria unaCategoria)
        {
            Categoria CategoriaToUpdate = _repository.FindById(id);
            ThrowExceptionSiNoEncuentraLaCategoria(CategoriaToUpdate);
            CategoriaToUpdate.Copiar(unaCategoria);
            _repository.Update(CategoriaToUpdate);            
            return CategoriaToUpdate;
        }

        private static void ThrowExceptionSiNoEncuentraLaCategoria(object obj)
        {
            if (obj == null)
            {
                throw new ElementoInvalidoException("No se encontro la categoría");
            }
        }

        private void ThrowExeptionSiCategoriaInvalida(Categoria unaCategoria)
        {
            unaCategoria.Validar();   
        }

        

        

    }
}
