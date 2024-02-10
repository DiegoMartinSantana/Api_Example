using Api.DTOs;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //lo hago private primero
        IPostService _titlesServices;

        //inicializo al crear que reciba por constructor
        public PostController(IPostService titlesServices)
        {
            _titlesServices = titlesServices;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() =>
            await _titlesServices.Get();

        //hago el metodo que sea del mismo tipo que el metodo que devuelve.

    }
}



