using System.Collections.Generic;

namespace UsersHierarchy.Domain
{
    public class Role
    {
        public int Id{get;set;}
        public string Name { get; set; }
        public int Parent { get; set; }
               
    }
}