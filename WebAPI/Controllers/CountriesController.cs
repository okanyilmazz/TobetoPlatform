using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _countryService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _countryService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCountryRequest createCountryRequest)
        {
            var result = await _countryService.AddAsync(createCountryRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCountryRequest updateCountryRequest)
        {
            var result = await _countryService.UpdateAsync(updateCountryRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCountryRequest deleteCountryRequest)
        {
            var result = await _countryService.DeleteAsync(deleteCountryRequest);
            return Ok(result);
        }
    }
}

