using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskWebApi.Data;
using TaskWebApi.Models;

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
            var list = _DbContext.tblItems.Where(x => x.IsDeleted != true).ToList();
            return Ok(list);
        }

        [HttpPost]
        [Route("AddItems")]
        public IActionResult AddItems([FromBody] tblItem item)
        {
            if (item != null)
            {
                if(item.ItemId == 0)
                { 
                    item.IsActive = true;
                    item.CreatedDate = DateTime.Now;
                    item.CreatedBy = 1;
                    item.IsDeleted = false;
                    _DbContext.tblItems.Add(item);  
                    int save = _DbContext.SaveChanges();
                    if (save > 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    var updateItem = _DbContext.tblItems.Where(x => x.ItemId == item.ItemId).FirstOrDefault();
                    if (updateItem != null)
                    {
                        updateItem.ItemId = item.ItemId;
                        updateItem.ItemDescription = item.ItemDescription;
                        updateItem.ItemCost = item.ItemCost;
                        updateItem.IsDeleted = false;
                        updateItem.IsActive = true;
                        updateItem.EditDate = DateTime.Now;
                        updateItem.EditBy = 1;
                        _DbContext.Update(updateItem);
                        int save = _DbContext.SaveChanges();
                        if (save > 0)
                        {
                            return Ok();
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                    
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteItems")]
        public IActionResult DeleteItems([FromQuery] int ItemId)
        {
            if (ItemId > 0)
            {
                var deleteItem = _DbContext.tblItems.FirstOrDefault(x => x.ItemId == ItemId);
                if (deleteItem != null)
                {
                    deleteItem.IsDeleted = true;
                    _DbContext.Update(deleteItem);
                    int save = _DbContext.SaveChanges();
                    if (save > 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound(); 
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }

}
