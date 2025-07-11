using Luftborn.Application.DTOs;
using Luftborn.Application.Interfaces;
using Luftborn.Domain;
using Luftborn.Domain.IRepository;
using Luftborn.SharedKernel.Bases;

namespace Luftborn.Application.Services
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IItemRepository _repository;
        
        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponseDataModel<GetAllItemsDataModel>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            var itemsDataModel = new GetAllItemsDataModel
            {
                Items = items.Select(item => Mapper.Map<GetItemDataModel>(item))
            };
            return BaseResponseDataModel<GetAllItemsDataModel>.Success(itemsDataModel, "Items retrieved successfully");
        }

        public async Task<BaseResponseDataModel<GetItemDataModel>> GetAsync(BaseRequestDataModel<GetItemRequestModel> request)
        {
            var record = await _repository.GetByIdAsync(request.Data.Id);
            if (record == null)
                return BaseResponseDataModel<GetItemDataModel>.NotFound(null, "Item Not Found");

            return BaseResponseDataModel<GetItemDataModel>.Success(Mapper.Map<GetItemDataModel>(record), "Item retrieved successfully");
        }

        public async Task<BaseResponseDataModel<CreateItemDataModel>> CreateAsync(BaseRequestDataModel<CreateItemRequestModel> request)
        {
            var item = new Item
            {
                Title = request.Data.Title,
                Description = request.Data.Description
            };

            await _repository.AddAsync(item);
            
            return BaseResponseDataModel<CreateItemDataModel>.Success(Mapper.Map<CreateItemDataModel>(item), "Item created successfully");
        }

        public async Task<BaseResponseDataModel<UpdateItemDataModel>> UpdateAsync(BaseRequestDataModel<UpdateItemRequestModel> request)
        {
            var existingItem = await _repository.GetByIdAsync(request.Data.Id);
            if (existingItem == null)
                return BaseResponseDataModel<UpdateItemDataModel>.NotFound(null, "Item Not Found");

            existingItem.Title = request.Data.Title;
            existingItem.Description = request.Data.Description;

            await _repository.UpdateAsync(existingItem);
            
            return BaseResponseDataModel<UpdateItemDataModel>.Success(Mapper.Map<UpdateItemDataModel>(existingItem), "Item updated successfully");
        }

        public async Task<BaseResponseDataModel<object>> DeleteAsync(BaseRequestDataModel<DeleteItemRequestModel> request)
        {
            var existingItem = await _repository.GetByIdAsync(request.Data.Id);
            if (existingItem == null)
                return BaseResponseDataModel<object>.NotFound(null, "Item Not Found");

            await _repository.DeleteAsync(request.Data.Id);
            
            return BaseResponseDataModel<object>.Success(null, "Item deleted successfully");
        }
    }
}
