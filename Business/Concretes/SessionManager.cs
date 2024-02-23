﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.SessionRequests;
using Business.Dtos.Responses.SessionResponses;
using Business.Messages;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class SessionManager : ISessionService
{

    ISessionDal _sessionDal;
    IMapper _mapper;
    SessionBusinessRules _sessionBusinessRules;

    public SessionManager(ISessionDal sessionDal, IMapper mapper, SessionBusinessRules sessionBusinessRules)
    {
        _sessionDal = sessionDal;
        _mapper = mapper;
        _sessionBusinessRules = sessionBusinessRules;
    }

    public async Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest)
    {
        Session session = _mapper.Map<Session>(createSessionRequest);
        Session createdSession = await _sessionDal.AddAsync(session);
        CreatedSessionResponse createdSessionResponse = _mapper.Map<CreatedSessionResponse>(createdSession);
        return createdSessionResponse;
    }

    public async Task<DeletedSessionResponse> DeleteAsync(DeleteSessionRequest deleteSessionRequest)
    {
        await _sessionBusinessRules.IsExistsSession(deleteSessionRequest.Id);
        Session session = await _sessionDal.GetAsync(predicate: s => s.Id == deleteSessionRequest.Id);
        Session deletedSession = await _sessionDal.DeleteAsync(session);
        DeletedSessionResponse deletedSessionResponse = _mapper.Map<DeletedSessionResponse>(deletedSession);
        return deletedSessionResponse;
    }

    public async Task<IPaginate<GetListSessionResponse>> GetListWithInstructorAsync(PageRequest pageRequest)
    {
        var session = await _sessionDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            predicate: s => s.AccountSessions.Any(a => a.Account.User.UserOperationClaims.Any(claim => claim.OperationClaim.Name == Roles.Instructor)),
            include: s => s
                .Include(s => s.OccupationClass)
                .Include(s => s.AccountSessions)
                .ThenInclude(s => s.Account)
                .ThenInclude(s => s.User)
                .ThenInclude(s => s.UserOperationClaims)
                .ThenInclude(s => s.OperationClaim));

        var mappedSession = _mapper.Map<Paginate<GetListSessionResponse>>(session);
        return mappedSession;
    }



    public async Task<IPaginate<GetListSessionResponse>> GetListAsync(PageRequest pageRequest)
    {
        var session = await _sessionDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: s => s
            .Include(s => s.OccupationClass));


        var mappedSession = _mapper.Map<Paginate<GetListSessionResponse>>(session);
        return mappedSession;
    }

    public async Task<GetListSessionResponse> GetByIdAsync(Guid id)
    {
        var session = await _sessionDal.GetAsync(
       predicate: s => s.Id == id,
       include: s => s
       .Include(s => s.OccupationClass));

        var mappedSession = _mapper.Map<GetListSessionResponse>(session);
        return mappedSession;
    }

    public async Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest)
    {
        await _sessionBusinessRules.IsExistsSession(updateSessionRequest.Id);
        Session session = _mapper.Map<Session>(updateSessionRequest);
        Session updatedSession = await _sessionDal.UpdateAsync(session);
        UpdatedSessionResponse updatedSessionResponse = _mapper.Map<UpdatedSessionResponse>(updatedSession);
        return updatedSessionResponse;
    }
}
