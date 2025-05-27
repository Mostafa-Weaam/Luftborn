using Microsoft.AspNetCore.Mvc;

namespace Luftborn.SharedKernel.Bases
{
    public abstract class BaseController : ControllerBase
    {
        #region Properties
        public Presenter Presenter { get; set; }

        #endregion
    }
}
