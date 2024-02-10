using Api.DTOs;
using System.Text.Json;

namespace Api.Services
{
    public class PostService : IPostService
    {
        //EN EL QUE HACE . VA HACER LA CONEXION AL JSON! 
        private HttpClient _httpClient;


        public PostService(HttpClient httpClient)
        {
            //ya contiene un base address desde my factory de mi program
            _httpClient = httpClient;
        }

        //tengo que hacela asincrona!
        public async Task<IEnumerable<PostDto>> Get()
        {
          

            //PUEDO USAR VAR OPORQUE LO DE LA DERECHA ME INDICA EL TIPO
            //le digo que obtenga el resultado !
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);

            //que obtenga el CONTENIDO (BODY) DEL RESULTADO ANTERIOR
            var body = await result.Content.ReadAsStringAsync();
            // creo para que no diferencie lasmayus y minus
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            //aca deserializo el json DEL BODY!
            //EN EL GENERICS EL TIPO  Y LE PASO DE DONDE!, desearilza un enumerable de tipo postdto, no solo un objeto
            var post =
            JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options); //LE PASO EL OPTIONS

            return post;

        }
    }
}

