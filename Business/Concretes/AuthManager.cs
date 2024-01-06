using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Core.CrossCuttingConcerns.Exceptions;
using Business.Messages;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Core.Entities;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IMapper _mapper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        public async Task<User> Register(RegisterAuthRequest registerAuthRequest, string password)
        {
            User user =  _mapper.Map<User>(registerAuthRequest);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(user);
            
            var result = await _userService.AddAsync(createUserRequest);
            return user;
        }

        public async Task<User> Login(LoginAuthRequest loginAuthRequest)
        {
            User user = _mapper.Map<User>(loginAuthRequest);
            var userToCheck = await _userService.GetByMailAsync(user.Email);

            if (userToCheck == null)
            {
                throw new BusinessException(BusinessMessages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(loginAuthRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                throw new BusinessException(BusinessMessages.PasswordUncorrect);
            }

            return user;
        }

        public Task UserExists(string email)
        {
            if (_userService.GetByMailAsync(email) != null)
            {
                throw new BusinessException(BusinessMessages.UserAlreadyExists);

            }
            throw new BusinessException("Success!");
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            var claims = await _userService.GetClaimsAsync(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }

    }
}