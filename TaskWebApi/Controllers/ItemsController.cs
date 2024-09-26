using Microsoft.AspNetCore.Mvc;
using TaskWebApi.Data;

namespace TaskWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly TaskDbContext _DbContext;

        public ItemsController(TaskDbContext context)
        {
            _DbContext = context;
        }

        [HttpGet]
        [Route("GetItems")]
        public IActionResult GetItems()
        {
            var list = _DbContext.tblItems.ToList();
            return Ok(list);
        }
    }

}
