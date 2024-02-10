namespace Api.DTOs
{
    public class PostDto
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        //tengo que avisarle que permite nulos con el ?
        public string? Title { get; set; }
        public string? Body { get; set; }

    }
}
