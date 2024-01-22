﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ContactRequests;
using Business.Dtos.Responses.ContactResponses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;
        IMapper _mapper;
        ContactBusinessRules _contactBusinessRules;

        public ContactManager(IContactDal contactDal, IMapper mapper, ContactBusinessRules contactBusinessRules)
        {
            _contactDal = contactDal;
            _mapper = mapper;
            _contactBusinessRules = contactBusinessRules;
        }

        public async Task<CreatedContactResponse> AddAsync(CreateContactRequest createContactRequest)
        {
            Contact contact = _mapper.Map<Contact>(createContactRequest);
            Contact addedContact = await _contactDal.AddAsync(contact);
            CreatedContactResponse createdContactResponse = _mapper.Map<CreatedContactResponse>(addedContact);
            return createdContactResponse;
        }

        public async Task<DeletedContactResponse> DeleteAsync(DeleteContactRequest deleteContactRequest)
        {
            await _contactBusinessRules.IsExistsContact(deleteContactRequest.Id);
            Contact contact = await _contactDal.GetAsync(predicate: c=>c.Id == deleteContactRequest.Id);
            Contact deletedContact = await _contactDal.DeleteAsync(contact,false);
            DeletedContactResponse deletedContactResponse = _mapper.Map<DeletedContactResponse>(deletedContact);
            return deletedContactResponse;
        }

        public async Task<GetListContactResponse> GetByIdAsync(Guid id)
        {
            var Contact = await _contactDal.GetAsync(p => p.Id == id);
            var mappedContact = _mapper.Map<GetListContactResponse>(Contact);
            return mappedContact;
        }

        public async Task<IPaginate<GetListContactResponse>> GetListAsync(PageRequest pageRequest)
        {
            var Contact = await _contactDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize);
            var mappedContact = _mapper.Map<Paginate<GetListContactResponse>>(Contact);
            return mappedContact;
        }

        public async Task<UpdatedContactResponse> UpdateAsync(UpdateContactRequest updateContactRequest)
        {
            await _contactBusinessRules.IsExistsContact(updateContactRequest.Id);
            Contact contact = _mapper.Map<Contact> (updateContactRequest);
            Contact updatedContact = await _contactDal.UpdateAsync(contact);
            UpdatedContactResponse updatedContactResponse = _mapper.Map<UpdatedContactResponse>(updatedContact);
            return updatedContactResponse;
        }
    }
}
