using Luftborn.Application.DTOs;
using Luftborn.SharedKernel.Bases;

namespace Luftborn.Application.Interfaces
{
    public interface IItemService
    {
        Task<BaseResponseDataModel<GetItemDataModel>> GetAsync(BaseRequestDataModel<GetItemRequestModel> request);
    }
}
