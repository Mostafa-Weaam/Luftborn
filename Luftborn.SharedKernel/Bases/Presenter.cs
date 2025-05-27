using Luftborn.SharedKernel.Middlewares.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Luftborn.SharedKernel.Bases
{
    public sealed class Presenter
    {
        #region Properties
        public ContentResult ContentResult { get; }
        #endregion

        #region Constructor
        public Presenter()
        {
            ContentResult = new ContentResult
            {
                ContentType = "application/json"
            };
        }
        #endregion

        #region Methods
        public async Task<ContentResult> Handle<TRequest, TResponse>(Func<BaseRequestDataModel<TRequest>, Task<BaseResponseDataModel<TResponse>>> serviceRequest, BaseRequestDataModel<TRequest> request)
        {
            BaseResponseDataModel<TResponse> response = await serviceRequest.Invoke(request);
            ContentResult.StatusCode = (int)response.StatusCode;
            ContentResult.Content = JsonHandler.Serialize(response);
            return ContentResult;
        }

        public async Task<ContentResult> Handle<TResponse>(Func<Task<BaseResponseDataModel<TResponse>>> serviceRequest)
        {
            BaseResponseDataModel<TResponse> response = await serviceRequest.Invoke();
            ContentResult.StatusCode = (int)response.StatusCode;
            ContentResult.Content = JsonHandler.Serialize(response);
            return ContentResult;
        }

        public ContentResult Handle(dynamic? serviceResult = null)
        {
            dynamic response = serviceResult;
            if (response != null)
            {
                ContentResult.StatusCode = (int)HttpStatusCode.OK;
                ContentResult.Content = JsonHandler.Serialize(response);
                return ContentResult;
            }
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonHandler.Serialize(response);
            return ContentResult;
        }

        #endregion
    }
}
