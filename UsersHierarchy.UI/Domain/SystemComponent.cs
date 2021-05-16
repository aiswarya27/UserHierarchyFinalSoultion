using System;
using System.Collections.Generic;
using System.Linq;

namespace UsersHierarchy.Domain
{
    public class SystemComponent
    {
        public IList<Role> roles { get; set; }
        public IList<User> users { get; set; }
       
        public SystemComponent()
        {
            
        }
        public SystemComponent(IList<Role> roles,IList<User> users)
        {
            this.roles = roles;
            this.users = users;

        }
        public IList<User> getSuboordinate(int userId)
        {
            return getUsersWithGivenRoles(getSubRolesForGivenRole(getUserRole(userId)));

        }

        public IList<Role> getSubRolesForGivenRole(int roleId)
        {
            Stack<Role> subRoles = new Stack<Role>();
            List<Role> listRoles = new List<Role>();
            List<Role> listSubRoles = this.roles.Where(x => x.Parent == roleId).ToList();
            foreach (Role subRole in listSubRoles)
            {
                subRoles.Push(subRole);

                while (subRoles.Any())
                {
                    var subrole = subRoles.Pop();
                    listRoles.Add(subrole);
                    if (subrole.Parent == 0)
                        return subRoles.ToList();
                    foreach (Role role in this.roles)
                    {
                        if (role.Parent == subrole.Id)
                        {
                            subRoles.Push(role);
                        }
                    }
                }
            }
            return listRoles.ToList();
        }

        public int getUserRole(int userId)
        {
            IList<User> user = this.users.Where(x => x.Id == userId).ToList();
            if (user.Count > 0)
            {
                return user.Single().Role;
            }
            return -1;
        }
        public IList<User> getUsersWithGivenRoles(IList<Role> roles)
        {   if(roles!=null && roles.Count>0)
                return this.users.Where(user => roles.Any(role => role.Id.Equals(user.Role))).ToList();
            return null;
        }


    }
}
