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
            string result = sm.getSubord(userID);
            if(result!="null")
                Console.WriteLine(result);
            else
                Console.WriteLine("Cant find any subordinates!!!");
            Console.ReadLine();
        }
    }
}
