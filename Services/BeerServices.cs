using Api.DTOs;
using Api.Models;
using Api.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Runtime.InteropServices;

namespace Api.Services
{
    public class BeerServices : ICommonServices<BeerDto,BeerInsertDto,BeerUpdateDto>
    {

        //como trabajamos con abstracciones, aca desconocemos todo lo relaconado con la bd
        // de eso se encarga nuestro Repository
        // por lo tanto desconocemos el contexto 

        private IRepository<Beer> _beerRepository;
        private IMapper _mapper;
        public BeerServices(IRepository<Beer> repository, IMapper mapper)
        {
            _mapper = mapper;
            _beerRepository = repository;
        }
        
        public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {

            if (beerInsertDto != null)
            {
                var beer = _mapper.Map<Beer>(beerInsertDto); // A PARTIR DE MI BEER INSERTE DTO DAME MI BEER

                await _beerRepository.Add(beer);
                await _beerRepository.Save();

                var beerDto = _mapper.Map<BeerDto>(beer);
                return beerDto;

            }
            return null;

        }

        

        public async Task<BeerDto> Delete(int id)
        {

            var beer = await _beerRepository.GetById(id);
            if (beer != null)
            {
                var beerDto = _mapper.Map<BeerDto>(beer);

                _beerRepository.Delete(beer);
               await _beerRepository.Save();
                return beerDto;
            }

            return null;

        }

        public async Task<IEnumerable<BeerDto>> Get()
        {
            var beers = await _beerRepository.Get();
            return beers.Select(b => _mapper.Map<BeerDto>(b)); // a partir de mi B dame mis dto 
            

        }

        public async Task<BeerDto> GetById(int id)
        {
            var beer = await  _beerRepository.GetById(id);

            if (beer != null)
            {
                var BeerDto = _mapper.Map<BeerDto>(beer);
                return BeerDto;
            }
            return null;
        }



        public async Task<BeerDto> Put(int id, BeerUpdateDto beerUpdate)
        {

            var beer = await _beerRepository.GetById(id);
            if (beer != null)
            {
                beer.BrandId = beerUpdate.BrandId;
                beer.NameBeer = beerUpdate.Name;
                beer.Alcohol = beerUpdate.Alcohol;

                 _beerRepository.Update(beer);
                await _beerRepository.Save();

                var beerDto = _mapper.Map<BeerDto>(beer);
                return beerDto;
            }

            return null;

        }
    }
}
