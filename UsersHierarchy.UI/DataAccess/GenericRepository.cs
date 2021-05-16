using System;
using System.Collections.Generic;
using System.Text;

namespace UsersHierarchy.UI.DataAccess
{
    public abstract class GenericRepository<T> : IDataRepository<T>
    {
        public abstract T Create(); 
      
    }
}
