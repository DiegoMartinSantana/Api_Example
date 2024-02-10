using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
       
        private IrandomServices _randomServiceSingleton;
        private IrandomServices _randomServiceScope;
        private IrandomServices _randomServiceTransient;

        private IrandomServices _randomService2Singleton;
        private IrandomServices _randomService2Scope;
        private IrandomServices _randomService2Transient;

        // y cuando crea el controller ACCEDO A TODOS 
        public RandomController(
            [FromKeyedServices("RandomServicesSingleton")] IrandomServices randomServiceSingleton ,
            [FromKeyedServices("RandomServicesSingleton")] IrandomServices randomService2Singleton,
            [FromKeyedServices("RandomServicesScoped")] IrandomServices randomServiceScoped,
            [FromKeyedServices("RandomServicesScoped")] IrandomServices randomService2Scoped,
            [FromKeyedServices("RandomServicesTransient")] IrandomServices randomServiceTransient,
            [FromKeyedServices("RandomServicesTransient")] IrandomServices randomService2Transient)
          
            // ARRIBA ACCEDI A LAS INTERFACES X SU KEY
        {

            // ACA LAS INICIALIZO 
                
            _randomServiceSingleton = randomServiceSingleton;
            _randomService2Singleton = randomService2Singleton;
            _randomServiceScope = randomServiceScoped;
            _randomService2Scope = randomService2Scoped;
            _randomServiceTransient = randomServiceTransient;
            _randomService2Transient = randomService2Transient;

        }
        [HttpGet]

        //DICCIONARIO = COLECCION TIPO CLAVE VALOR, CLAVE TIPO STRING VALOR TIPO INT
        public ActionResult<Dictionary<string,int>> Get()
        {
            var result = new Dictionary<string, int>();
            result.Add("Singleton 1 ", _randomServiceSingleton.Value); // LE PASO EL VALUE DEL SERVICE . QUE CREA UN NUMBER ALEATORIO
            result.Add("Singleton 2 ", _randomService2Singleton.Value);
            result.Add("SCOPE 1 ", _randomServiceScope.Value);
            result.Add("SCOPE 2 ", _randomService2Scope.Value);
            result.Add("TRANSIENT 1 ", _randomServiceTransient.Value);
            result.Add("TRANSIENT  2 ", _randomService2Transient.Value);

            return result;

        }


    }
}
