using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _userService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [CacheRemove("Users.Get")]
    [CustomValidation(typeof(CreateUserRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateUserRequest createUserRequest)
    {
        var result = await _userService.AddAsync(createUserRequest);
        return Ok(result);
    }

    [CacheRemove("Users.Get")]
    [CustomValidation(typeof(UpdateUserRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserRequest updateUserRequest)
    {
        var result = await _userService.UpdateAsync(updateUserRequest);
        return Ok(result);
    }

    [CacheRemove("Users.Get")]
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteUserRequest deleteProductRequest)
    {
        var result = await _userService.DeleteAsync(deleteProductRequest);
        return Ok(result);
    }
}