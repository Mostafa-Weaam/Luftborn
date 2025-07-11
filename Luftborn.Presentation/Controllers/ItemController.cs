using Luftborn.Application.DTOs;
using Luftborn.Application.Interfaces;
using Luftborn.Application.IStartegies;
using Luftborn.Domain;
using Luftborn.Domain.IRepository;
using Luftborn.SharedKernel.Bases;
using Luftborn.SharedKernel.Common.APIConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace Luftborn.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BaseController
    {
        public IItemService _itemService { get; set; }

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [MapToApiVersion(APIVersion.Version1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDataModel<GetAllItemsDataModel>))]
        public async Task<IActionResult> GetAll() =>
            await Presenter.Handle(_itemService.GetAllAsync);

        [HttpGet("{id}")]
        [MapToApiVersion(APIVersion.Version1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDataModel<GetItemDataModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id) =>
            await Presenter.Handle(_itemService.GetAsync, new BaseRequestDataModel<GetItemRequestModel> { Data = new GetItemRequestModel { Id = id } });

        [HttpPost]
        [MapToApiVersion(APIVersion.Version1)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BaseResponseDataModel<CreateItemDataModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateItemRequestModel request) =>
            await Presenter.Handle(_itemService.CreateAsync, new BaseRequestDataModel<CreateItemRequestModel> { Data = request });

        [HttpPut("{id}")]
        [MapToApiVersion(APIVersion.Version1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDataModel<UpdateItemDataModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateItemRequestModel request)
        {
            request.Id = id; // Ensure the ID from route matches the request
            return await Presenter.Handle(_itemService.UpdateAsync, new BaseRequestDataModel<UpdateItemRequestModel> { Data = request });
        }

        [HttpDelete("{id}")]
        [MapToApiVersion(APIVersion.Version1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDataModel<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id) =>
            await Presenter.Handle(_itemService.DeleteAsync, new BaseRequestDataModel<DeleteItemRequestModel> { Data = new DeleteItemRequestModel { Id = id } });
    } 
}
