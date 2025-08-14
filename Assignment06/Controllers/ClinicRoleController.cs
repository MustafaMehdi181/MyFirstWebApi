using Microsoft.AspNetCore.Mvc;
using Assignment06.Models;
using Assignment06.Services;

namespace Assignment06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicRolesController : ControllerBase
    {
        private readonly IClinicRoleService _clinicRoleService;

        public ClinicRolesController(IClinicRoleService clinicRoleService)
        {
            _clinicRoleService = clinicRoleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_clinicRoleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var role = _clinicRoleService.GetById(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ClinicRole clinicRole)
        {
            _clinicRoleService.Add(clinicRole);
            return CreatedAtAction(nameof(GetById), new { id = clinicRole.RoleID }, clinicRole);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ClinicRole clinicRole)
        {
            if (id != clinicRole.RoleID) return BadRequest();
            _clinicRoleService.Update(clinicRole);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clinicRoleService.Delete(id);
            return NoContent();
        }
    }
}
