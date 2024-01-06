﻿using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var result = await _contactService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _contactService.GetByIdAsync(id);
            return Ok(result);
        }

        [CustomValidation(typeof(CreateContactRequestValidator))]
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateContactRequest createContactRequest)
        {
            var result = await _contactService.AddAsync(createContactRequest);
            return Ok(result);
        }

        [CustomValidation(typeof(UpdateContactRequestValidator))]
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateContactRequest updateContactRequest)
        {
            var result = await _contactService.UpdateAsync(updateContactRequest);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteContactRequest deleteContactRequest)
        {
            var result = await _contactService.DeleteAsync(deleteContactRequest);
            return Ok(result);
        }
    }
}
