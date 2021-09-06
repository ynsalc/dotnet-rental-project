using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarAlgorithm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentsController : ControllerBase
    {
        private ISegmentService _segmentService;

        public SegmentsController(ISegmentService segmentService)
        {
            _segmentService = segmentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _segmentService.GetAll();
            if(result.Count > 0)
            {
                return Ok(result);
            }
            return BadRequest("Listeleme yapılamadı");
        }

        [HttpPost]
        public IActionResult Add(Segment segment)
        {
            _segmentService.Add(segment);
            return Ok("Segment Eklendi");
        }
    }
}
