using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountSkillsController : ControllerBase
    {
        IAccountSkillService _accountSkillsService;

        public AccountSkillsController(IAccountSkillService accountSkillsService)
        {
            _accountSkillsService = accountSkillsService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _accountSkillsService.GetListAsync(pageRequest);
            return Ok(result);
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var result = await _accountSkillsService.GetByIdAsync(Id);
            return Ok(result);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAccountSkillRequest createAccountSkillRequest)
        {
            var result = await _accountSkillsService.AddAsync(createAccountSkillRequest);
            return Ok(result);
        }


        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountSkillRequest updateAccountSkillRequest)
        {
            var result = await _accountSkillsService.UpdateAsync(updateAccountSkillRequest);
            return Ok(result);
        }


        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteAccountSkillRequest deleteAccountSkillRequest)
        {
            var result = await _accountSkillsService.DeleteAsync(deleteAccountSkillRequest);
            return Ok(result);
        }
    }
}
