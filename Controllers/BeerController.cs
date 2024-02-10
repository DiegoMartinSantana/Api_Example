using Api.DTOs;
using Api.Models;
using Api.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        //el contexto es una prop privada demi contrlador
        private IValidator<BeerInsertDto> _beerInsertValidator;   
        private ICommonServices<BeerDto, BeerInsertDto, BeerUpdateDto> _beerServices;

        // recibo x constructor el context

        public BeerController( IValidator<BeerInsertDto> BeerInsertValidator,
            ICommonServices<BeerDto, BeerInsertDto, BeerUpdateDto> Services)
        {
            _beerServices = Services;
            _beerInsertValidator = BeerInsertValidator; 
        }
        [HttpGet]

        public async Task<IEnumerable<BeerDto>> Get() =>
            await _beerServices.Get();
        
        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beer = await _beerServices.GetById(id);
            return beer == null ? NotFound() : Ok(beer);

        }


        [HttpPost]

        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            //las validaciones estan bien aca porque devuelven un  http.
            var validationResult =_beerInsertValidator.Validate(beerInsertDto);

            if (!validationResult.IsValid) { 
            return BadRequest(validationResult.Errors);
            }
            var beer  = await _beerServices.Add(beerInsertDto);

            
            return CreatedAtAction(nameof(GetById), new { id = beer.Id}, beer);


        }



        [HttpPut("{id}")]

        public async Task<ActionResult<BeerDto>> Put(int id, BeerUpdateDto beerUpdate)
        {
            var beer = await _beerServices.Put(id, beerUpdate);
            return beer == null ? NotFound() : Ok(beer);
        }

        //TIENEN QU ERECIBIR UN ID!
        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDto>>Delete(int id)
        {
            var beer = await _beerServices.Delete(id);
            return beer == null ? NotFound() : Ok(beer);

        }


    }
}
