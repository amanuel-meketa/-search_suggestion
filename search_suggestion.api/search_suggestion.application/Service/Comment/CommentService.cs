using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using search_suggestion.application.Contracts.Search;
using search_suggestion.data.Model;

namespace search_suggestion.application.Service.Search
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public CommentService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiUrl"] + "/comments";
        }

        public async Task<List<Comment>> Get()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<Comment>>(jsonString);

                return comments;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving comments: {ex.Message}");
                throw;
            }
        }

    }
}
