using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountRequests;
using Business.Dtos.Requests.AuthRequests;
using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.AuthResponses;
using Business.Messages;
using Business.Rules.BusinessRules;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private IUserService _userService;
    private ITokenHelper _tokenHelper;
    private IMapper _mapper;
    private UserBusinessRules _userBusinessRules;
    private IAccountService _accountService;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper, UserBusinessRules userBusinessRules, IAccountService accountService)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _accountService = accountService;
    }

    public async Task<LoginResponse> Register(RegisterAuthRequest registerAuthRequest, string password)
    {
        await _userBusinessRules.IsExistsUserMail(registerAuthRequest.Email);
        User user = _mapper.Map<User>(registerAuthRequest);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(user);

        var addedUser = await _userService.AddAsync(createUserRequest);
        var getUserResponse = await _userService.GetByIdAsync(addedUser.Id);

        User mappedUser = _mapper.Map<User>(getUserResponse);

        await _accountService.AddAsync(new CreateAccountRequest
        {
            Id = addedUser.Id,
            UserId = addedUser.Id,
            BirthDate = DateTime.MinValue,
            Description = null,
            NationalId = null,
            PhoneNumber = null,
            ProfilePhotoPath = null,
        });
        var result = await CreateAccessToken(mappedUser);

        return result;
    }

    public async Task<User> Login(LoginAuthRequest loginAuthRequest)
    {
        var userToCheck = await _userService.GetByMailAsync(loginAuthRequest.Email);
        User user = _mapper.Map<User>(userToCheck);

        if (userToCheck == null)
        {
            throw new BusinessException(BusinessMessages.UserNotFound);
        }

        if (!HashingHelper.VerifyPasswordHash(loginAuthRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            throw new BusinessException(BusinessMessages.PasswordUncorrect);
        }

        user = _mapper.Map<User>(userToCheck);
        return user;
    }

    public async Task<LoginResponse> CreateAccessToken(User user)
    {
        var claims = await _userService.GetClaimsAsync(user);
        var mapped = _mapper.Map<List<OperationClaim>>(claims);

        var accessToken = _tokenHelper.CreateToken(user, mapped);
        LoginResponse loginResponse = _mapper.Map<LoginResponse>(accessToken);

        return loginResponse;
    }

}