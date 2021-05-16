using System;
using System.Collections.Generic;
using System.Text;

namespace UsersHierarchy.UI.DataAccess
{
    public interface IDataRepository<T>
    {
        T Create();

    }
}
