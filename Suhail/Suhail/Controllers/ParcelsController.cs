using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Suhail.Models;

namespace Suhail.Controllers
{
	using System;

	using LinqKit;

	[Route("api/[controller]")]
    [ApiController]
    public class ParcelsController : ControllerBase
    {
        private readonly SuhailContext _context;

        public ParcelsController(SuhailContext context)
        {
            _context = context;
        }

        // GET: api/Parcels
        [HttpGet]
        public IEnumerable<Parcel> GetParcel()
        {
            return _context.Parcel;
        }

        // GET: api/Parcels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParcel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parcel = await _context.Parcel.FindAsync(id);

            if (parcel == null)
            {
                return NotFound();
            }

            return Ok(parcel);
        }

        // PUT: api/Parcels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParcel([FromRoute] long id, [FromBody] Parcel parcel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parcel.ID)
            {
                return BadRequest();
            }

            _context.Entry(parcel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelExists(id))
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

        // POST: api/Parcels
        [HttpPost]
        public async Task<IActionResult> PostParcel([FromBody] Parcel parcel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Parcel.Add(parcel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParcel", new { id = parcel.ID }, parcel);
        }

        // DELETE: api/Parcels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcel([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parcel = await _context.Parcel.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }

            _context.Parcel.Remove(parcel);
            await _context.SaveChangesAsync();

            return Ok(parcel);
        }

        private bool ParcelExists(long id)
        {
            return _context.Parcel.Any(e => e.ID == id);
        }

	    [HttpGet("{BlockNumber,SubdivisionNumber,LandUseGroup}")]
		public async Task<IActionResult> GetParcel(string blockNumber,string subdivisionNumber, LandUseGroups? landUseGroup)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var predicate = PredicateBuilder.New<Parcel>();
			 
			if (!string.IsNullOrEmpty(blockNumber))
			{
				predicate = predicate.And(x => x.BlockNumber.Equals(blockNumber));
			}

			if (!string.IsNullOrEmpty(subdivisionNumber))
			{
				predicate = predicate.And(x => x.SubdivisionNumber.Equals(blockNumber));
			}

			if (landUseGroup.HasValue)
			{
				predicate = predicate.And(x => x.LandUseGroup == landUseGroup.Value);
			}


			var parcels = this._context.Parcel.Where(predicate);

			if (parcels == null)
			{
				return NotFound();
			}

			return Ok(parcels);
		}
	}
}