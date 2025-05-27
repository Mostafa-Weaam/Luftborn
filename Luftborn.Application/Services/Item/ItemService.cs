using Luftborn.Application.DTOs;
using Luftborn.Application.Interfaces;
using Luftborn.Domain.IRepository;
using Luftborn.SharedKernel.Bases;

namespace Luftborn.Application.Services
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IITemRepository _repository;
        public async Task<BaseResponseDataModel<GetItemDataModel>> GetAsync(BaseRequestDataModel<GetItemRequestModel> request)
        {
            var record = await _repository.GetByIdAsync(request.Data.Id);
            if (record == null)
                return BaseResponseDataModel<GetItemDataModel>.NotFound(null, "Item Not Found");

            return BaseResponseDataModel<GetItemDataModel>.Success(Mapper.Map<GetItemDataModel>(record), "Item retrieved successfully");
        }
    }
}
