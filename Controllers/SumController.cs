using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumController : ControllerBase
    {
        //EJEMPLO PRROGMACION SINCRONA , 1 A 1 EJECUTA
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            //"duerme" para el proceso por unos segundos. simulacion de algo en este caso
            Thread.Sleep(1000);
            Console.WriteLine("Simulacion conexion Bd");

            Thread.Sleep(2000);
            Console.WriteLine("Simulacion conexion Bd FINALIZADA");


            sw.Stop();

            return Ok(sw.Elapsed); // RETORNA EL TIEMPO TRANSCURRIDO
        }

        [HttpGet("async")]
        
        public async Task<IActionResult> GetAsync()
        {
            //recibe una funcion de primera clase asique le armo la function lambda y recibe un generics 
           

            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Simulacion DE UNA TASK");
                return 8;

            });

            //TENGO QUE INICIAR LAS TASK


            task1.Start();
               

            var result = await task1; // con await me aseguro que no siga ejecutando hasta terminar el task1 

            Console.WriteLine("result = " +  result);
            return Ok();

        }


    }
}
