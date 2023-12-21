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
    public class AccountsController : ControllerBase
    {
        IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _accountService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _accountService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetBySessionId")]
        public async Task<IActionResult> GetBySessionIdAsync(Guid id)
        {
            var result = await _accountService.GetBySessionIdAsync(id);
            return Ok(result);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAccountRequest createAccountRequest)
        {
            var result = await _accountService.AddAsync(createAccountRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountRequest updateAccountRequest)
        {
            var result = await _accountService.UpdateAsync(updateAccountRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountRequest deleteAccountRequest)
        {
            var result = await _accountService.DeleteAsync(deleteAccountRequest);
            return Ok(result);
        }
    }
}
