using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using UsersHierarchy.Domain;

namespace UsersHierarchy.BL.System
{
    class SystemDataConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return typeof(SystemComponent).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
 
                JObject item = JObject.Load(reader);

                if (item["users"] != null&& item["roles"] != null)
                {
                    var users = item["users"].ToObject<IList<User>>(serializer);
                    var roles = item["roles"].ToObject<IList<Role>>(serializer);                    

                    return new SystemComponent(roles,users);
                }
         
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
