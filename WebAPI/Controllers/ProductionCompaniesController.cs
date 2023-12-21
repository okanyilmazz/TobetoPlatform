using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class ProductionCompaniesController : ControllerBase
{
    IProductionCompanyService _productionCompanyService;

    public ProductionCompaniesController(IProductionCompanyService productionCompanyService)
    {
        _productionCompanyService = productionCompanyService;
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _productionCompanyService.GetListAsync();
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateProductionCompanyRequest createProductionCompanyRequest)
    {
        var result = await _productionCompanyService.AddAsync(createProductionCompanyRequest);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductionCompanyRequest updateProductionCompanyRequest)
    {
        var result = await _productionCompanyService.UpdateAsync(updateProductionCompanyRequest);
        return Ok(result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteProductionCompanyRequest deleteProductionCompanyRequest)
    {
        var result = await _productionCompanyService.DeleteAsync(deleteProductionCompanyRequest);
        return Ok(result);
    }
}

