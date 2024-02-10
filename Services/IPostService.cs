using Api.DTOs;

namespace Api.Services
{
    public interface IPostService
    {
        //Creo la interfaz que define que hace y no el como
        //le digo que obtiene x una task de enumerable ( solo tiene el ITERADOR DEL TIPO QUE L EPASE YO! ,
        // gasta menos memoria ) 
        public Task<IEnumerable<PostDto>> Get();
    }
}
