using Microsoft.AspNetCore.Mvc;

namespace MediAR.Modules.Membership.Api.Controllers
{
    [ApiController]
    [Route(BaseUrl + "/[controller]")]
    internal abstract class BaseController : ControllerBase
    {
        protected const string BaseUrl = "membership";
    }
}