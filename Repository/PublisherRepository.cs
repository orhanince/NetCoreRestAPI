
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using NetCoreRestAPI.Data;
using NetCoreRestAPI.Dtos;
using NetCoreRestAPI.Helpers;
using NetCoreRestAPI.Models;
using NetCoreRestAPI.Services;

namespace NetCoreRestAPI.Repository
{
    public class PublisherRepository : IPublisherRepository
{
        private readonly MyAppContext _context;
        private readonly IMapper _iMapper;
        public PublisherRepository(MyAppContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }
        public async Task<List<PublisherDto>> GetPublisherListAsync()
        {
            var publishers = await _context.Publishers.ToListAsync();
            return  _iMapper.Map<List<PublisherDto>>(publishers);
        }

        public async Task<PublisherDto> AddPublisherAsync(string name)
        {
            var existPublisher = await _context.Publishers.FirstOrDefaultAsync(u => u.Name == SlugGenerator.GenerateSlug(name));  
            if (existPublisher != null)
            {
                throw new ArgumentNullException(nameof(existPublisher));
            }
            
            var publisher = new Publisher {
                Name = name,
                Active = true
            };
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
            return _iMapper.Map<PublisherDto>(publisher);
        }

        public async Task<bool> PublisherExistsAsync(int publisherID)
        {
            var publisher = await _context.Publishers.FirstOrDefaultAsync(u => u.Id == publisherID);
            if (publisher == null)
            {
                return false;
            }
            return true;

        }
        public async Task<PublisherDto> GetPublisherAsync(int publisherID)
        {
            var publisher = await _context.Publishers.FirstOrDefaultAsync(u => u.Id == publisherID);
            if (publisher == null)
            {
                throw new KeyNotFoundException($"Publisher with ID {publisherID} not found.");
            }
            return _iMapper.Map<PublisherDto>(publisher);   
        }
    }
}
