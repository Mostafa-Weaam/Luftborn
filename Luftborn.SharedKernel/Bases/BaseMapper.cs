using AutoMapper;

namespace Luftborn.SharedKernel.Bases
{
    public class BaseMapper : Profile
    {
        protected readonly int _currentLanguage;
        public BaseMapper()
        {
        }
    }
}
