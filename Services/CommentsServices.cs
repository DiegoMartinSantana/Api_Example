using Api.DTOs;
using System.Text.Json;

namespace Api.Services
{
    public class CommentsServices : ICommentsServices
    {


        private HttpClient _httpClient;

        public CommentsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        
        public async Task< IEnumerable<CommentsDto> >Get()
        {

            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var body = await result.Content.ReadAsStringAsync();   

            var post = JsonSerializer.Deserialize<IEnumerable<CommentsDto>>(body,options);


            return post;
            


        }
    }
}
