using Api.DTOs;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsControler : ControllerBase
    {


        ICommentsServices _commentsService;

        public CommentsControler(ICommentsServices CommentsServices)
        {
            _commentsService = CommentsServices;
        }


        [HttpGet("Comments")]

        public async Task<IEnumerable<CommentsDto>> Get() => await _commentsService.Get();
            


    }
}
