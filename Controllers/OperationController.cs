using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")] //ruta , puedo modificarlo
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet("All")]
        public decimal someGet ( decimal a , decimal b)
        {
            return a * b;

        }
        [HttpPost]
        public decimal somePost(decimal a, decimal b, Numbers num )
        {
            return num.A - num.B;


        }
        [HttpPut]
        public decimal somePut(decimal a, decimal b)
        {
            return a / b;

        }
        [HttpDelete]
        public decimal someDelete(decimal a, decimal b)
        {
            return a + b;

        }
    }
}

public class Numbers {

    public decimal A { get; set; }
    public decimal B { get; set; }


}