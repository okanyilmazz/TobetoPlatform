using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.InstructorRequests;
using Business.Dtos.Responses.InstructorResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using Core.Entities;
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
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;
        IMapper _mapper;
        InstructorBusinessRules _instructorBusinessRules;

        public InstructorManager(IInstructorDal instructorDal, IMapper mapper, InstructorBusinessRules instructorBusinessRules)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest createInstructorRequest)
        {
            Instructor instructor = _mapper.Map<Instructor>(createInstructorRequest);
            Instructor createdInstructor = await _instructorDal.AddAsync(instructor);
            CreatedInstructorResponse createdInstructorResponse = _mapper.Map<CreatedInstructorResponse>(createdInstructor);
            return createdInstructorResponse;
        }

        public async Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest deleteInstructorRequest)
        {
            Instructor instructor = _mapper.Map<Instructor>(deleteInstructorRequest);
            Instructor deletedInstructor = await _instructorDal.DeleteAsync(instructor);
            DeletedInstructorResponse deletedInstructorResponse = _mapper.Map<DeletedInstructorResponse>(deletedInstructor);
            return deletedInstructorResponse;
        }

        public async Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest)
        {
            var instructor = await _instructorDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize,
                include: u => u
                .Include(u => u.User)
                );

            var mappedSession = _mapper.Map<Paginate<GetListInstructorResponse>>(instructor);
            return mappedSession;
        }

        public async Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest updateInstructorRequest)
        {
            Instructor instructor = _mapper.Map<Instructor>(updateInstructorRequest);
            Instructor updatedInstructor = await _instructorDal.UpdateAsync(instructor);
            UpdatedInstructorResponse updatedInstructorResponse = _mapper.Map<UpdatedInstructorResponse>(updatedInstructor);
            return updatedInstructorResponse;
        }
    }
}
