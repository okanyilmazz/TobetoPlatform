using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using DataAccess.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountHomeworksController : ControllerBase
    {
        IAccountHomeworkService _accountHomeworkService;

        public AccountHomeworksController(IAccountHomeworkService accountHomeworkService)
        {
            _accountHomeworkService = accountHomeworkService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _accountHomeworkService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAccountHomeworkRequest createAccountHomeworkRequest)
        {
            var result = await _accountHomeworkService.AddAsync(createAccountHomeworkRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountHomeworkRequest deleteAccountHomeworkRequest)
        {
            var result = await _accountHomeworkService.DeleteAsync(deleteAccountHomeworkRequest);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountHomeworkRequest updateAccountHomeworkRequest)
        {
            var result = await _accountHomeworkService.UpdateAsync(updateAccountHomeworkRequest);
            return Ok(result);
        }
    }
}
