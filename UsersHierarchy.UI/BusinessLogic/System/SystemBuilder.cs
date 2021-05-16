using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using UsersHierarchy.Domain;
using UsersHierarchy.UI.DataAccess;

namespace UsersHierarchy.BL.System
{
    public class SystemBuilder
    {                      
        private readonly IDataRepository<SystemComponent> systemRepository;
        private SystemComponent systemComponent;

        public SystemBuilder(IDataRepository<SystemComponent> systemRepository)
        {
            this.systemRepository = systemRepository;
        }

        public void BuildSystem()
        {
            systemComponent = systemRepository.Create();
            
        }
        
        public string getSubord(int id)
        {           
            return JsonConvert.SerializeObject(this.systemComponent.getSuboordinate(id),Formatting.Indented);
        }
    }
}
