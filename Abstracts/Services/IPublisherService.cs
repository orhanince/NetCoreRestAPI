using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Services
{
    public interface IPublisherService
    {
        Task<List<PublisherDto>> GetPublisherListAsync();
        Task<PublisherDto> AddPublisherAsync(AddPublisherDto addPublisherDto);
        Task <PublisherDto> GetPublisherAsync(GetPublisherDto getPublisherDto);
        Task<bool> PublisherExistsAsync(int publisherID);
    }
}
