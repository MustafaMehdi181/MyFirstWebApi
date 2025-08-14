using Assignment06.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment06.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var patients = await _patientService.GetAllPatientsAsync(cancellationToken);
            return Ok(patients);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientByIdAsync(id, cancellationToken);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Patient patient, CancellationToken cancellationToken)
        {
            var rowsAffected = await _patientService.CreatePatientAsync(patient, cancellationToken);
            if (rowsAffected > 0)
                return CreatedAtAction(nameof(GetById), new { id = patient.PatientID }, patient);
            return BadRequest("Failed to create patient.");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Patient patient, CancellationToken cancellationToken)
        {
            if (id != patient.PatientID)
                return BadRequest("ID mismatch.");

            var updated = await _patientService.UpdatePatientAsync(patient, cancellationToken);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _patientService.DeletePatientAsync(id, cancellationToken);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}
