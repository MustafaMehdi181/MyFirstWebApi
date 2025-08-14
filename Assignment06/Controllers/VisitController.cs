using Microsoft.AspNetCore.Mvc;
using Assignment06.Models;
using Assignment06.Services;

namespace Assignment06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitDetailsController : ControllerBase
    {
        private readonly IVisitDetailService _visitDetailService;

        public VisitDetailsController(IVisitDetailService visitDetailService)
        {
            _visitDetailService = visitDetailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_visitDetailService.GetAllVisitDetails());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var visitDetail = _visitDetailService.GetVisitDetailById(id);
            if (visitDetail == null) return NotFound();
            return Ok(visitDetail);
        }

        [HttpPost]
        public IActionResult Create([FromBody] VisitDetail visitDetail)
        {
            _visitDetailService.AddVisitDetail(visitDetail);
            return CreatedAtAction(nameof(GetById), new { id = visitDetail.VisitID }, visitDetail);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] VisitDetail visitDetail)
        {
            if (id != visitDetail.VisitID) return BadRequest();
            _visitDetailService.UpdateVisitDetail(visitDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _visitDetailService.DeleteVisitDetail(id);
            return NoContent();
        }
    }
}
