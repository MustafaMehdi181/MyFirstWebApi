using Assignment06.Models;
using Microsoft.AspNetCore.Mvc;
using Assignment06.Services;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorServices _doctorService;

    public DoctorsController(IDoctorServices doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var doctors = await _doctorService.GetAllDoctorsAsync(cancellationToken);
        return Ok(doctors);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var doctor = await _doctorService.GetDoctorByIdAsync(id, cancellationToken);
        if (doctor == null)
            return NotFound();
        return Ok(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Doctor doctor, CancellationToken cancellationToken)
    {
        var rowsAffected = await _doctorService.CreateDoctorAsync(doctor, cancellationToken);
        if (rowsAffected > 0)
            return CreatedAtAction(nameof(GetById), new { id = doctor.DoctorID }, doctor);
        return BadRequest("Failed to create doctor.");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Doctor doctor, CancellationToken cancellationToken)
    {
        if (id != doctor.DoctorID)
            return BadRequest("ID mismatch.");

        var updated = await _doctorService.UpdateDoctorAsync(doctor, cancellationToken);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await _doctorService.DeleteDoctorAsync(id, cancellationToken);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
