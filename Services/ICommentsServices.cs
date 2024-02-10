using Api.DTOs;

namespace Api.Services
{
    public interface ICommentsServices
    {
        public Task< IEnumerable<CommentsDto>> Get(); 
    }
}
