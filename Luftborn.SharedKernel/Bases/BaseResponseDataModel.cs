using Luftborn.SharedKernel.Common.Enum;

namespace Luftborn.SharedKernel.Bases
{
    public class BaseResponseDataModel<TResult>
    {
        public TResult Result { get; set; }
        public string Message { get; set; }
        public string ReferenceCode { get; set; }
        public ResponseStatusCode StatusCode { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public string StatusName => StatusCode.ToString();


        /// <summary>
        /// Return Success Code => 1 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static BaseResponseDataModel<TResult> Success(TResult result, string message)
        {
            return new BaseResponseDataModel<TResult>()
            {
                StatusCode = ResponseStatusCode.Successfully,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// Return NotFound Code => 2
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static BaseResponseDataModel<TResult> NotFound(TResult result, string message)
        {
            return new BaseResponseDataModel<TResult>()
            {
                StatusCode = ResponseStatusCode.NotFound,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// Return MultiError code => 4 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static BaseResponseDataModel<TResult> MultiError(TResult result, string message)
        {
            return new BaseResponseDataModel<TResult>()
            {
                StatusCode = ResponseStatusCode.MultiError,
                Message = message,
                Result = result,
            };

        }

        public static BaseResponseDataModel<TResult> MultiError(Dictionary<string, List<string>> dic, string message)
        {
            return new BaseResponseDataModel<TResult>()
            {
                StatusCode = ResponseStatusCode.MultiError,
                Message = message,
                Errors = dic,
            };
        }

        /// <summary>
        /// Return InternalError code => 6  
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static BaseResponseDataModel<TResult> SystemError(TResult result, string message)
        {
            return new BaseResponseDataModel<TResult>()
            {
                StatusCode = ResponseStatusCode.SystemInternalError,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// Return Dublicate code => 7  
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static BaseResponseDataModel<TResult> Dublicate(TResult result, string message)
        {
            return new BaseResponseDataModel<TResult>()
            {
                StatusCode = ResponseStatusCode.Dublicate,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// Return InvalidData code => 8  
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static BaseResponseDataModel<TResult> InvalidData(TResult result, string message)
        {
            return new BaseResponseDataModel<TResult>()
            {
                StatusCode = ResponseStatusCode.InvalidData,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static BaseResponseDataModel<TResult> NotAuthorized(TResult result, string message)
        {
            return new BaseResponseDataModel<TResult>()
            {
                StatusCode = ResponseStatusCode.NotAuthorized,
                Message = message,
                Result = result,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static BaseResponseDataModel<TResult> AlreadyExists(TResult result, string message)
        {
            return new BaseResponseDataModel<TResult>()
            {
                StatusCode = ResponseStatusCode.AlreadyExists,
                Message = message,
                Result = result,
            };
        }
    }
}
