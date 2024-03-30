using AutoMapper;
using search_suggestion.application.Dtos;
using search_suggestion.data.Model;

namespace search_suggestion.application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}
