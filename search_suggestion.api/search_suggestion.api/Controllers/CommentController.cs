using Microsoft.AspNetCore.Mvc;
using search_suggestion.application.Contracts.Search;

namespace search_suggestion.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _searchService;

        public CommentController(ICommentService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            try
            {
                var comments = await _searchService.Get();
                return Ok(comments);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting comments: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving comments.");
            }
        }
    }
}
