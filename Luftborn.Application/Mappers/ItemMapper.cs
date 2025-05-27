using AutoMapper;
using Luftborn.Application.DTOs;
using Luftborn.Domain;
using Luftborn.SharedKernel.Bases;

namespace Luftborn.Application.Mappers
{
    public class ItemMapper : BaseMapper
    {
        public ItemMapper()
        {
            CreateMap<Item, GetItemDataModel>();
        }
    }
}
