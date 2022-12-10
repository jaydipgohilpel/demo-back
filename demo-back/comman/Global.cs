using demo_proj_backend.Models;
using System.Net;
using System.Reflection;

namespace demo_back.comman
{
    public class Global
    {
        public static HttpResponseMessage CreateResponse(HttpRequestMessage pRequest, HttpStatusCode pStatusCode, string pStrMessage)
        {
           Error pObjResponse = new Error
            {
                Status = (int)pStatusCode,
                Message = pStrMessage
            };
            return pRequest.CreateResponse((HttpStatusCode)pObjResponse.Status, pObjResponse);
        }
    }
}
