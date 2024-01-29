using AutoMapper;
using Business.Dtos.Responses.AuthResponses;
using Core.Utilities.Security.JWT;

namespace Business.Profiles;

public class AuthProfile:Profile
{
	public AuthProfile()
	{
		CreateMap<AccessToken, LoginResponse>().ReverseMap();
	}
}

