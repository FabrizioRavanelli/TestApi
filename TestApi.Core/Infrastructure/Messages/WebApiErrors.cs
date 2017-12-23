using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Core.Infrastructure.Messages
{
    [DataContract(Namespace = "http://schemas.bofrost.de/bo2.Core")]
    public enum WebApiErrorTypes
    {
        /// <summary>
        /// Fehler-Typ signalisiert die falsche Verwendung der API.
        /// Die Anwendung soll hier keine detailierten Informationen preisgeben.
        /// </summary>
        [EnumMember]
        InvalidApiCall,
    }

    public static class WebApiErrors
    {
        /// <summary>
        /// Fehler signalisiert die falsche Verwendung der API.
        /// Die Anwendung gibt hier keine detailierten Informationen preis.
        /// </summary>
        public static ReturnObject InvalidApiCall()
        {
            return ReturnObject.GetInstanceCustomError(WebApiErrorTypes.InvalidApiCall, "", "", false);
        }
    }
}
