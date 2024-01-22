using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.UserResponses;
using Business.Rules;
using Core.DataAccess.Paging;
using Core.Entities;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IMapper _mapper;
        UserBusinessRules _userBusinessRules;

        public UserManager(IUserDal userDal, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _mapper = mapper;
            _userDal = userDal;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest)
        {
            User user = _mapper.Map<User>(createUserRequest);
            User addedUser = await _userDal.AddAsync(user);
            var responseUser = _mapper.Map<CreatedUserResponse>(addedUser);
            return responseUser;
        }

        public async Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            await _userBusinessRules.IsExistsUser(updateUserRequest.Id);
            User user = _mapper.Map<User>(updateUserRequest);
            User updatedUser = await _userDal.UpdateAsync(user);
            UpdatedUserResponse mappedProduct = _mapper.Map<UpdatedUserResponse>(updatedUser);
            return mappedProduct;
        }

        public async Task<DeletedUserResponse> DeleteAsync(DeleteUserRequest deleteUserRequest)
        {
            await _userBusinessRules.IsExistsUser(deleteUserRequest.Id);
            User user = await _userDal.GetAsync(predicate: u => u.Id == deleteUserRequest.Id);
            User deletedUser = await _userDal.DeleteAsync(user, true);
            DeletedUserResponse responseUser = _mapper.Map<DeletedUserResponse>(deletedUser);
            return responseUser;
        }

        public async Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest)
        {
            var userList = await _userDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
            var mappedList = _mapper.Map<Paginate<GetListUserResponse>>(userList);
            return mappedList;
        }

        public async Task<GetUserResponse> GetByIdAsync(Guid? id)
        {
            User user = await _userDal.GetAsync(predicate: u => u.Id == id);
            GetUserResponse getUserResponse = _mapper.Map<GetUserResponse>(user);
            return getUserResponse;
        }

        public async Task<GetUserResponse> GetByMailAsync(string email)
        {
            var getUser = await _userDal.GetAsync(u => u.Email == email);
            GetUserResponse getUserResponse = _mapper.Map<GetUserResponse>(getUser);
            return getUserResponse;
        }

        public async Task<List<OperationClaim>> GetClaimsAsync(User user)
        {
            return await _userDal.GetClaims(user);

        }
    }
}

