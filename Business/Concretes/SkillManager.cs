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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;
        IMapper _mapper;
        SkillBusinessRules _skillBusinessRules;

        public SkillManager(ISkillDal skillDal, IMapper mapper, SkillBusinessRules skillBusinessRules)
        {
            _skillDal = skillDal;
            _mapper = mapper;
            _skillBusinessRules = skillBusinessRules;
        }

        public async Task<CreatedSkillResponse> AddAsync(CreateSkillRequest createSkillRequest)
        {
            Skill skill = _mapper.Map<Skill>(createSkillRequest);
            Skill addedSkill = await _skillDal.AddAsync(skill);
            CreatedSkillResponse createdSkillResponse = _mapper.Map<CreatedSkillResponse>(addedSkill);
            return createdSkillResponse;
        }

        public async Task<DeletedSkillResponse> DeleteAsync(DeleteSkillRequest deleteSkillRequest)
        {
            await _skillBusinessRules.IsExistsSkill(deleteSkillRequest.Id);
            Skill skill = _mapper.Map<Skill>(deleteSkillRequest);
            Skill deletedSkill = await _skillDal.DeleteAsync(skill);
            DeletedSkillResponse deletedSkillResponse = _mapper.Map<DeletedSkillResponse>(deletedSkill);
            return deletedSkillResponse;
        }

        public async Task<UpdatedSkillResponse> UpdateAsync(UpdateSkillRequest updateSkillRequest)
        {
            await _skillBusinessRules.IsExistsSkill(updateSkillRequest.Id);
            Skill skill = _mapper.Map<Skill>(updateSkillRequest);
            Skill updatedSkill = await _skillDal.UpdateAsync(skill);
            UpdatedSkillResponse updatedSkillResponse = _mapper.Map<UpdatedSkillResponse>(updatedSkill);
            return updatedSkillResponse;
        }

        public async Task<IPaginate<GetListSkillResponse>> GetListAsync()
        {
            var skills = await _skillDal.GetListAsync();
            var mappedSkills = _mapper.Map<Paginate<GetListSkillResponse>>(skills);
            return mappedSkills;
        }
    }
}
