using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAS.Api.v2.Infrastructure;
using SAS.Api.v2.Models;

namespace SAS.Api.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly DomainContext _context;

        public GoodsController(DomainContext context)
        {
            _context = context;
        }

        // GET: api/Goods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goods>>> GetGoodsList()
        {
            return await _context.Goods.ToListAsync();
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goods>> GetGoodsById(long id)
        {
            var goods = await _context.Goods.FindAsync(id);

            if (goods == null)
            {
                return NotFound();
            }

            return goods;
        }

        // POST: api/Googs
        [HttpPost]
        public async Task<ActionResult<Goods>> AddGoogs(Goods goods)
        {
            _context.Goods.Add(goods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoodsById", new { id = goods.Id }, goods);
        }

        // PUT: api/Goods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoods(long id, Goods goods)
        {
            if (id != goods.Id)
            {
                return BadRequest();
            }

            _context.Entry(goods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool GoodsExists(long id)
        {
            return _context.Goods.Any(e => e.Id == id);
        }
    }
}
