using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.DataAccess.Paging;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _addressService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var result = await _addressService.GetByIdAsync(Id);
            return Ok(result);
        }

        [CustomValidation(typeof(CreateAddressRequestValidator))]
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAddressRequest createAddressRequest)
        {
            var result = await _addressService.AddAsync(createAddressRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteAddressRequest deleteAddressRequest)
        {
            var result = await _addressService.DeleteAsync(deleteAddressRequest);
            return Ok(result);
        }

        [CustomValidation(typeof(UpdateAddressRequestValidator))]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAddressRequest updateAddressRequest)
        {
            var result = await _addressService.UpdateAsync(updateAddressRequest);
            return Ok(result);
        }
    }
}
