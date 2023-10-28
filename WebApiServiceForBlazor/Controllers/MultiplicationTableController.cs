using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiServiceForBlazor.Services;

namespace WebApiServiceForBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiplicationTableController : ControllerBase
    {
        private readonly MultiplicationTableService _tableService;

        public MultiplicationTableController(MultiplicationTableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _tableService.Generate());
        }
    }
}
