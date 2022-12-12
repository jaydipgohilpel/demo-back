using System.Runtime.Serialization;
using System.Xml.Linq;

namespace demo_back.comman
{
   
     public static class DatabaseConnection
    {
        private static string Connection_String = "Data Source=(localdb)\\LocalDb;Initial Catalog=myLocalDb;Integrated Security=True";
        public static string AccessConnectionString()
        {
            return Connection_String;
        }
      
    }
}
