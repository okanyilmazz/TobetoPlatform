using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class CertificatesController : Controller
{
    ICertificateService _certificateService;

    public CertificatesController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _certificateService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _certificateService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [CustomValidation(typeof(CreateCertificateRequestValidator))]
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateCertificateRequest createCertificateRequest)
    {
        var result = await _certificateService.AddAsync(createCertificateRequest);
        return Ok(result);
    }

    [CustomValidation(typeof(UpdateCertificateRequestValidator))]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCertificateRequest updateCertificateRequest)
    {
        var result = await _certificateService.UpdateAsync(updateCertificateRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteCertificateRequest deleteCertificateRequest)
    {
        var result = await _certificateService.DeleteAsync(deleteCertificateRequest);
        return Ok(result);
    }
}

