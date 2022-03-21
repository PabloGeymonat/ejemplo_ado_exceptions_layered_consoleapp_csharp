using System;
using System.Collections.Generic;


namespace DataAccess.Interfaces
{
   public interface IRepository<T>
    {
		T Add(T entity);
		T Update(T entity);
		bool Remove(int id);
		bool Remove(T entity);
		T FindById(int id);
		
	}

}
