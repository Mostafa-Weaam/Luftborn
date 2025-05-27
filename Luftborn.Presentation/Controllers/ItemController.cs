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

        [HttpGet]
        [MapToApiVersion(APIVersion.Version1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDataModel<GetItemDataModel>))]
        public async Task<IActionResult> Get([FromQuery] GetItemRequestModel request) =>
            await Presenter.Handle(_itemService.GetAsync, new BaseRequestDataModel<GetItemRequestModel> { Data = request });
    }
}
