using Newtonsoft.Json;
using System.IO;


namespace UsersHierarchy.BL.System
{
    public  class JsonParser<SystemComponent>
    {
        private const string FILEPATH = "E:\\UsersHierarchy\\UsersHierarchy.UI\\UsersHierarchy.UI\\InputFile\\userHeirarchy.json";
        
        public static SystemComponent parseJson()
        {
            using (StreamReader r = new StreamReader(FILEPATH))
            {
                string json = r.ReadToEnd();               
                return JsonConvert.DeserializeObject<SystemComponent>(json, new SystemDataConverter());                                           
            }
        }      
    }
}
