using Luftborn.Application.DTOs;
using Luftborn.SharedKernel.Bases;

namespace Luftborn.Application.Interfaces
{
    public interface IItemService
    {
        Task<BaseResponseDataModel<GetAllItemsDataModel>> GetAllAsync();
        Task<BaseResponseDataModel<GetItemDataModel>> GetAsync(BaseRequestDataModel<GetItemRequestModel> request);
        Task<BaseResponseDataModel<CreateItemDataModel>> CreateAsync(BaseRequestDataModel<CreateItemRequestModel> request);
        Task<BaseResponseDataModel<UpdateItemDataModel>> UpdateAsync(BaseRequestDataModel<UpdateItemRequestModel> request);
        Task<BaseResponseDataModel<object>> DeleteAsync(BaseRequestDataModel<DeleteItemRequestModel> request);
    }
}
