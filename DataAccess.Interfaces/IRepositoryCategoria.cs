using System.Collections.Generic;

using Domain;

namespace DataAccess.Interfaces
{
    public interface IRepositoryCategoria: IRepository<Categoria>
   {

        List<Categoria> FindAll();
        Categoria FindByName(string nombre);
        List<Categoria> FindSimilares(string nombre);

    }

}
