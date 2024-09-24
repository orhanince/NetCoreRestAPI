using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Repository
{
   public interface IPublisherRepository
    {
        Task<List<PublisherDto>> GetPublisherListAsync();
        Task<PublisherDto> AddPublisherAsync(string name);
        Task<PublisherDto> GetPublisherAsync(int publisherID);
        Task<bool> PublisherExistsAsync(int publisherID);
    } 
}
