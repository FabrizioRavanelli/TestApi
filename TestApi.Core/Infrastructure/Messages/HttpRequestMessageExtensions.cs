using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Core.Infrastructure.Messages
{
    public static class HttpRequestMessageExtensions
    {
        #region Public

        public static HttpResponseMessage CreateReturnObjectResponse<TModel>(this HttpRequestMessage oRequest, ReturnObject ret, Func<TModel> onSuccess)
        {
            HttpResponseMessage oResponse = oRequest.CreateResponse(HttpStatusCode.Forbidden);

            if (ret.IsSuccess)
            {
                oResponse = oRequest.CreateResponse(HttpStatusCode.OK, onSuccess());
            }
            else if (WebApiErrorTypes.InvalidApiCall.Equals(ret.ErrorType))
            {
                oResponse = oRequest.CreateResponse(HttpStatusCode.Forbidden);
            }
            else
            {
                //MessageBoxModel oModel = CreateMessageBoxModel(ret);
                //oResponse = oRequest.CreateResponse(HttpStatusCode.Forbidden, oModel);
            }

            return oResponse;
        }

        public static HttpResponseMessage CreateReturnObjectResponse(this HttpRequestMessage oRequest, ReturnObject ret)
        {
            HttpResponseMessage oResponse = oRequest.CreateResponse(HttpStatusCode.Forbidden);

            if (ret.IsSuccess)
            {
                oResponse = oRequest.CreateResponse(HttpStatusCode.OK);
            }
            else if (WebApiErrorTypes.InvalidApiCall.Equals(ret.ErrorType))
            {
                oResponse = oRequest.CreateResponse(HttpStatusCode.Forbidden);
            }
            else
            {
                //MessageBoxModel oModel = CreateMessageBoxModel(ret);
                //oResponse = oRequest.CreateResponse(HttpStatusCode.Forbidden, oModel);
            }

            return oResponse;
        }
        
        #endregion
    }
}
