using Assignment06.Models;
using Assignment06.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class VisitTypesController : ControllerBase
{
    private readonly IVisitTypeService _service;

    public VisitTypesController(IVisitTypeService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult Add([FromBody] VisitType visitType)
    {
        _service.Add(visitType);
        return CreatedAtAction(nameof(GetAll), visitType);
    }
}
