using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using search_suggestion.application.Contracts.Search;
using search_suggestion.application.Dtos;
using search_suggestion.data.Model;

namespace search_suggestion.application.Service.Search
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        private readonly IMapper _mapper;

        public CommentService(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _apiUrl = configuration["ApiUrl"] + "comments";
        }


        public async Task<List<CommentDto>> Get()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<CommentDto>>(jsonString);

                return _mapper.Map<List<CommentDto>>(comments); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving comments: {ex.Message}");
                throw;
            }
        }

    }
}
