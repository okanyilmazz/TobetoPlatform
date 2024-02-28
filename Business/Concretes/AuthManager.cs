using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountRequests;
using Business.Dtos.Requests.AuthRequests;
using Business.Dtos.Requests.MailRequests;
using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.AuthResponses;
using Business.Dtos.Responses.UserResponses;
using Business.Messages;
using Business.Rules.BusinessRules;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private IUserService _userService;
    private ITokenHelper _tokenHelper;
    private IMapper _mapper;
    private UserBusinessRules _userBusinessRules;
    private IAccountService _accountService;
    private IMailService _mailService;


    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper, UserBusinessRules userBusinessRules, IAccountService accountService, IMailService mailService)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _accountService = accountService;
        _mailService = mailService;
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

    public async Task ChangePassword(ChangePasswordRequest changePasswordRequest)
    {
        byte[] passwordHash, passwordSalt;
        var userResponse = await _userService.GetByIdAsync(changePasswordRequest.UserId);
        User user = _mapper.Map<User>(userResponse);

        HashingHelper.CreatePasswordHash(changePasswordRequest.NewPassword, out passwordHash, out passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        var test = _mapper.Map<UpdateUserRequest>(user);
        await _userService.UpdateAsync(test);
    }

    public async Task<bool> PasswordResetAsync(string email)
    {
        GetUserResponse user = await _userService.GetByMailAsync(email);

        if (user != null)
        {
            User mappedUser = _mapper.Map<User>(user);
            var claims = await _userService.GetClaimsAsync(mappedUser);
            var mapped = _mapper.Map<List<OperationClaim>>(claims);
            var resetToken = _tokenHelper.CreateToken(mappedUser, mapped);

            byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken.Token);
            resetToken.Token = WebEncoders.Base64UrlEncode(tokenBytes);

            SendPasswordResetMailRequest sendPasswordResetMailRequest = new SendPasswordResetMailRequest
            {
                UserId = user.Id,
                ResetToken = resetToken.Token,
                To = email
            };
            UpdateUserRequest updateUserRequest = new UpdateUserRequest
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                PasswordReset = resetToken.Token,
                Status = user.Status
            };


            await _userService.UpdateAsync(updateUserRequest);

            await _mailService.SendPasswordResetMailAsync(sendPasswordResetMailRequest);
            return true;
        }
        throw new BusinessException(BusinessMessages.UserNotFound);

    }
}