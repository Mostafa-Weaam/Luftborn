using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Luftborn.SharedKernel.Bases
{
    public class BaseService
    {
        public IMapper Mapper { get; set; }
    }
}
