using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsContext _context;

        public ParkingLotsController(ParkingLotsContext context)
        {
            _context = context;
        }

        // GET: api/ParkingLots
        [HttpGet]
        public IEnumerable<ParkingLot> GetParkingLot()
        {
            return _context.ParkingLot;
        }

        // GET: api/ParkingLots/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParkingLot([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parkingLot = await _context.ParkingLot.FindAsync(id);

            if (parkingLot == null)
            {
                return NotFound();
            }

            return Ok(parkingLot);
        }

        // PUT: api/ParkingLots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingLot([FromRoute] string id, [FromBody] ParkingLot parkingLot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parkingLot.LotId)
            {
                return BadRequest();
            }

            _context.Entry(parkingLot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingLotExists(id))
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

        // POST: api/ParkingLots
        [HttpPost]
        public async Task<IActionResult> PostParkingLot([FromBody] ParkingLot parkingLot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParkingLot.Add(parkingLot);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParkingLotExists(parkingLot.LotId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParkingLot", new { id = parkingLot.LotId }, parkingLot);
        }

        // DELETE: api/ParkingLots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParkingLot([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parkingLot = await _context.ParkingLot.FindAsync(id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            _context.ParkingLot.Remove(parkingLot);
            await _context.SaveChangesAsync();

            return Ok(parkingLot);
        }

        private bool ParkingLotExists(string id)
        {
            return _context.ParkingLot.Any(e => e.LotId == id);
        }
    }
}