﻿using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Core.CrossCuttingConcerns.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        IDistrictService _districtService;

        public DistrictsController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _districtService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _districtService.GetListAsync();
            return Ok(result);
        }

        [CustomValidation(typeof(CreateDistrictRequestValidator))]
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateDistrictRequest createDistrictRequest)
        {
            var result = await _districtService.AddAsync(createDistrictRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteDistrictRequest deleteDistrictRequest)
        {
            var result = await _districtService.DeleteAsync(deleteDistrictRequest);
            return Ok(result);
        }

        [CustomValidation(typeof(UpdateDistrictRequestValidator))]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateDistrictRequest updateDistrictRequest)
        {
            var result = await _districtService.UpdateAsync(updateDistrictRequest);
            return Ok(result);
        }
    }
}
