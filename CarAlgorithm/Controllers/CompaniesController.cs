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
    public class CompaniesController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _companyService.GetAll();
            if(result.Count > 0)
            {
                return Ok(result);
            }
            return BadRequest("Listeleme Yapılamadı");
        }

        [HttpPost]
        public IActionResult Add(Company company)
        {
            _companyService.Add(company);
            return Ok("Firma Eklendi");
        }

        [HttpGet("getbyid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _companyService.GetByIdWithInclude(id);
            return Ok(result);
        }
    }
}
