using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week11Task.Data;
using Week11Task.Models;
using Week11Task.Services.UnitsServices;

namespace Week11Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitsServices unitsServices;

        public UnitsController(IUnitsServices unitsServices)
        {
            this.unitsServices = unitsServices;
        }

        // GET: api/Units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnits()
        {
            var response = await unitsServices.GetUnits();
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }

        // GET: api/Units/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Unit>> GetUnit([FromRoute] int id)
        {
            var response = await unitsServices.GetUnit(id);
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }

        // PUT: api/Units/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUnit([FromRoute] int id, [FromBody] Unit unit)
        {
            if (id != unit.Id) return BadRequest();
            var response = await unitsServices.UpdateUnit(unit);
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }

        // POST: api/Units
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Unit>> PostUnit([FromBody] Unit unit)
        {
            var response = await unitsServices.CreateUnit(unit);
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }

        // DELETE: api/Units/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUnit([FromRoute] int id)
        {
            var response = await unitsServices.DeleteUnit(id);
            return response.Success ? Ok(response.Data) : BadRequest(response.Message);
        }
    }
}
