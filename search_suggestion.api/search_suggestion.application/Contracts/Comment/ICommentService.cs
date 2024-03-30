using search_suggestion.data.Model;

namespace search_suggestion.application.Contracts.Search
{
    public interface ICommentService
    {
        Task<List<Comment>> Get();
    }
}
