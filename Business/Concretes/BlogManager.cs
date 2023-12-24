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
    public class BlogManager : IBlogService
    {

        IBlogDal _blogDal;
        IMapper _mapper;
        BlogBusinessRules _blogBusinessRules;

        public BlogManager(IBlogDal blogDal, IMapper mapper, BlogBusinessRules blogBusinessRules)
        {
            _blogDal = blogDal;
            _mapper = mapper;
            _blogBusinessRules = blogBusinessRules;

        }

        public async Task<CreatedBlogResponse> AddAsync(CreateBlogRequest createBlogRequest)
        {
            Blog blog = _mapper.Map<Blog>(createBlogRequest);
            Blog createdBlog = await _blogDal.AddAsync(blog);
            CreatedBlogResponse createdBlogResponse = _mapper.Map<CreatedBlogResponse>(createdBlog);
            return createdBlogResponse;
        }

        public async Task<DeletedBlogResponse> DeleteAsync(DeleteBlogRequest deleteBlogRequest)
        {
            await _blogBusinessRules.IsExistsBlog(deleteBlogRequest.Id);
            Blog blog = _mapper.Map<Blog>(deleteBlogRequest);
            Blog deletedBlog = await _blogDal.DeleteAsync(blog,true);
            DeletedBlogResponse deletedBlogResponse = _mapper.Map<DeletedBlogResponse>(deletedBlog);
            return deletedBlogResponse;
        }

        public async Task<GetListBlogResponse> GetByIdAsync(Guid Id)
        {
            var blogs = await _blogDal.GetAsync(b => b.Id == Id);
            var mappedBlogs = _mapper.Map<GetListBlogResponse>(blogs);
            return mappedBlogs;
        }

        public async Task<IPaginate<GetListBlogResponse>> GetListAsync()
        {
            var blogs = await _blogDal.GetListAsync();
            var mappedBlogs = _mapper.Map<Paginate<GetListBlogResponse>>(blogs);
            return mappedBlogs;
        }

        public async Task<UpdatedBlogResponse> UpdateAsync(UpdateBlogRequest updateBlogRequest)
        {
            await _blogBusinessRules.IsExistsBlog(updateBlogRequest.Id);
            Blog blog = _mapper.Map<Blog>(updateBlogRequest);
            Blog updatedBlog = await _blogDal.UpdateAsync(blog);
            UpdatedBlogResponse updatedBlogResponse = _mapper.Map<UpdatedBlogResponse>(updatedBlog);
            return updatedBlogResponse;
        }
    }
}
