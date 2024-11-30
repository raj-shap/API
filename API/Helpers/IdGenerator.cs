using Microsoft.SqlServer.Server;
using System;

namespace API.Helpers
{
    public static class IdGenerator
    {
        public static string GenerateUniqueId()
        {
            //generates a new GUID.
            Guid guid = Guid.NewGuid(); 
            
            //.ToString("N") converts the GUID to a 32 - character string without dashes.
            return guid.ToString("N");
        }
    }
}
