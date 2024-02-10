using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private IPeopleServices _PeopleServices;

        //AÑADI LA CREACION AL BUILDER CON UN ADD SINGLETON! 
        public PeopleController( IPeopleServices peopleServices)
        {
            
        }
        //POR KEY : 

       // public PeopleController([FromKeyedServices("PeopleServices"]  IPeopleServices peopleServices)
        

        

        [HttpGet("all")]
        public List<People> Get() => People.ListPeople;


        [HttpGet("id/{id}")]
        public ActionResult<People> Get(int id)
        {

            //obtengo el recurso siempre y cuando exista

            var Pepe = People.ListPeople.FirstOrDefault(p => p.Id == id);

            //evaluo, devuelve null si no existe el first or default

            if (Pepe == null)
            {
                //retorno error en este caso 404 = no encontrado!
                return NotFound();
            }
            //OK = CODIGO 200 ( TODO OK)
            return Ok(Pepe);
        }
        [HttpGet("search/{search}")]
        public List<People> Get(string search) => People.ListPeople.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        // I ACTION PARA NO RETORNAR NADA! EJEMPLO ALGO SOLO PROCESO
        public IActionResult Add(People people)
        {
            //LE PASO EL METODO DE LA CLASE QUE USA LA INTERFAZ
            if (!_PeopleServices.Validate(people))
            {   
                return BadRequest();
            }
            //SI ESTA OK ADD
            People.ListPeople.Add(people);
            //COMO SOLO E SPROCESO, RETORNO SOLO EL CODIGO QUE ESTA OK. SIN CONTENIDO
            return NoContent();

        }

    }
}

public class People
{
    public static List<People> ListPeople = new List<People>
    {

        new People()
        {
            Id=1,Name="Pepe",
            BornDate= new DateTime(2000,06,03)
        },new People()
        {
            Id=2,Name="Diego",
            BornDate= new DateTime(1996,01,02)


        }, new People(){
            Id=3,Name="Arnaldo",
            BornDate= new DateTime(1900,12,12)

        },

    };

    public int Id { get; set; }
    public string Name { get; set; }

    public DateTime BornDate { get; set; }


}
