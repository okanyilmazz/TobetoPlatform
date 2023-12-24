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
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
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
            Session session = _mapper.Map<Session>(deleteSessionRequest);
            Session deletedSession = await _sessionDal.DeleteAsync(session, true);
            DeletedSessionResponse deletedSessionResponse = _mapper.Map<DeletedSessionResponse>(deletedSession);
            return deletedSessionResponse;
        }

        public async Task<IPaginate<GetListSessionResponse>> GetListAsync()
        {
            var sessions = await _sessionDal.GetListAsync();
            var mappedSessions = _mapper.Map<Paginate<GetListSessionResponse>>(sessions);
            return mappedSessions;
        }

        public async Task<GetListSessionResponse> GetByIdAsync(Guid id)
        {
            var session = await _sessionDal.GetAsync(s => s.Id == id);
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
}
