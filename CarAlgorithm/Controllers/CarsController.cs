using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarAlgorithm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            _carService.Add(car);
            return Ok("Araç Eklendi");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return BadRequest("Araçlar Listelenemedi");
        }

        [HttpGet("getbycompanyid")]
        public IActionResult GetByCompanyId(int companyId)
        {
            var result = _carService.GetByCompanyId(companyId);
            if(result.Count > 0)
            {
                return Ok(result);
            }
            return BadRequest("Firmanın Aracı Yok!");
        }

        [HttpGet("getbytopcars")]
        public IActionResult GetAllTopCars() 
        {
            var result = _carService.GetAllTopCars();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return BadRequest("Top List Not Found.");
        }

        [HttpGet("getbyid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carService.GetById(id);
            return Ok(result);
        }
    }
}
