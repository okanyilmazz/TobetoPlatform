using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _addressService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var result = await _addressService.GetByIdAsync(Id);
            return Ok(result);
        }

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

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAddressRequest updateAddressRequest)
        {
            var result = await _addressService.UpdateAsync(updateAddressRequest);
            return Ok(result);
        }
    }
}
