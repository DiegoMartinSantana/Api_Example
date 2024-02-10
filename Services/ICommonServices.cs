using Api.DTOs;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    //HACEMOS QUE RECIBA GENERICS. UNO PARA CADA DTO
    public interface ICommonServices<T,TI,TU>
    {
        //TENER TODO SEPARADO.
        //CONTROLADOR COMUNICA POR HTTPS. ASIQUE LO QUE NO SEA ESO UTILIZO UNA INTERFACE

        //        public async Task<ActionResult<BeerDto>> GetById(int id)
      
        //EJEM DE ARIBA ,  EL ACTION RESULT SE ENCARGA EL CONTROLLER


         Task<T> GetById(int id);
        Task<IEnumerable<T>> Get();
        Task<T> Add(TI beerInsertDto);
        Task<T> Put(int id, TU beerUpdate);
        Task<T> Delete(int id);



    }
}
