using Microsoft.AspNetCore.Http.HttpResults;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Repository;

namespace NetCoreRestAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _iPublisherRepository;
        public PublisherService(IPublisherRepository iPublisherRepository)
        {
             _iPublisherRepository = iPublisherRepository;
        }

        public async Task<List<PublisherDto>> GetPublisherListAsync()
        {
            return await _iPublisherRepository.GetPublisherListAsync();
        }

        public async Task<PublisherDto> AddPublisherAsync(AddPublisherDto addPublisherDto)
        {
            return await _iPublisherRepository.AddPublisherAsync(addPublisherDto.name);
        }

        public async Task<PublisherDto> GetPublisherAsync(GetPublisherDto getPublisherDto)
        {
            return await _iPublisherRepository.GetPublisherAsync(getPublisherDto.publisherID);
        }
        public async Task<bool> PublisherExistsAsync(int publisherID)
        {
            return await _iPublisherRepository.PublisherExistsAsync(publisherID);
        }
    }
}