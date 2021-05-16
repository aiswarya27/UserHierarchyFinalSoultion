using System;
using UsersHierarchy.BL.System;
using UsersHierarchy.UI.DataAccess;

namespace UsersHierarchy.UI
{
    class Program
    {
        static void Main(string[] args)
        {            
            CreateSystem();            
        }
        public static void CreateSystem()
        {            
            Console.WriteLine("Enter the user id to get subordinates:");
            int userID = Convert.ToInt32(Console.ReadLine());
            SystemRepository sr = new SystemRepository();
            SystemBuilder sm = new SystemBuilder(sr);
            sm.BuildSystem();
            Console.Write(sm.getSubord(userID));
            Console.ReadLine();
        }
    }
}
