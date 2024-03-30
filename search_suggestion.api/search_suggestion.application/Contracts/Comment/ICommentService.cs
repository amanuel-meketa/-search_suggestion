using search_suggestion.application.Dtos;

namespace search_suggestion.application.Contracts.Search
{
    public interface ICommentService
    {
        Task<List<CommentDto>> Get();
    }
}
