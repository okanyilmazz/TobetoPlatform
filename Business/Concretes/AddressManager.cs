using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;
        IMapper _mapper;
        AddressBusinessRules _addressBusinessRules;

        public AddressManager(IAddressDal addressDal, IMapper mapper, AddressBusinessRules addressBusinessRules)
        {
            _addressDal = addressDal;
            _mapper = mapper;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<CreatedAddressResponse> AddAsync(CreateAddressRequest createAddressRequest)
        {
            Address address = _mapper.Map<Address>(createAddressRequest);
            Address createdAddress = await _addressDal.AddAsync(address);
            CreatedAddressResponse createdAddressResponse = _mapper.Map<CreatedAddressResponse>(createdAddress);
            return createdAddressResponse;
        }

        public async Task<DeletedAddressResponse> DeleteAsync(DeleteAddressRequest deleteAddressRequest)
        {
            await _addressBusinessRules.IsExistsAddress(deleteAddressRequest.Id);
            Address address = await _addressDal.GetAsync(predicate: l => l.Id == deleteAddressRequest.Id);
            Address deletedAddress = await _addressDal.DeleteAsync(address);
            DeletedAddressResponse deletedAddressResponse = _mapper.Map<DeletedAddressResponse>(deletedAddress);
            return deletedAddressResponse;
        }

        public async Task<GetListAddressResponse> GetByIdAsync(Guid Id)
        {
            var addresss = await _addressDal.GetAsync(
                predicate: a => a.Id == Id,
                include: a => a
                .Include(a => a.District)
                .Include(a => a.City)
                .Include(a => a.Country));
            var mappedAddresses = _mapper.Map<GetListAddressResponse>(addresss);
            return mappedAddresses;
        }

        public async Task<IPaginate<GetListAddressResponse>> GetListAsync()
        {
            var address = await _addressDal.GetListAsync(
                include: a => a
                .Include(a => a.District)
                .Include(a => a.City)
                .Include(a => a.Country));
            var mappedAddresses = _mapper.Map<Paginate<GetListAddressResponse>>(address);
            return mappedAddresses;
        }

        public async Task<UpdatedAddressResponse> UpdateAsync(UpdateAddressRequest updateAddressRequest)
        {
            Address address = _mapper.Map<Address>(updateAddressRequest);
            Address updatedAddress = await _addressDal.UpdateAsync(address);
            UpdatedAddressResponse updatedAddressResponse = _mapper.Map<UpdatedAddressResponse>(updatedAddress);
            return updatedAddressResponse;
        }
    }
}
