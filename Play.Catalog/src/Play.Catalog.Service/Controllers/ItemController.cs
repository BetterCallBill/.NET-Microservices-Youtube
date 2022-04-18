using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{
    // https://localhost:5001/items
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        public static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(), "", "", 5, DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }

        // ActionResult<ItemDto>: return more than one type
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItemById(Guid id)
        {
            var existingItem = items.FirstOrDefault(item => item.Id == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            return existingItem;
        }

        // POST
        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), "", "", 5, DateTimeOffset.UtcNow);

            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public IActionResult Put(Guid id)
        {
            var existingItem = items.FirstOrDefault(item => item.Id == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            return NoContent();
        }
    }
}