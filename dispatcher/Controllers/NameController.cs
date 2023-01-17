using dispatcher.BLL;
using dispatcher.Models;
using Microsoft.AspNetCore.Mvc;

namespace dispatcher.Controllers
{
    [ApiController]
    [Route("names")]
    public class NameController : ControllerBase
    {
        [HttpPost]
        public OkObjectResult PostNamesAsync(List<Name> names)
        {
            var result = Storage.Dispatch(names);
            return Ok(value: result);
        }
    }
}
