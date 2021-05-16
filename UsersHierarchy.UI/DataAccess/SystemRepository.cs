using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UsersHierarchy.BL.System;
using UsersHierarchy.UI.DataAccess;
using UsersHierarchy.Domain;

namespace UsersHierarchy.UI.DataAccess
{
    public class SystemRepository : GenericRepository<SystemComponent>
    {
        private SystemComponent _systemComponent;     

        public SystemRepository()
        {
                     
        }
        
        public override SystemComponent Create()
        {
            _systemComponent= JsonParser<SystemComponent>.parseJson();
            return _systemComponent;
        }       
    }
}
