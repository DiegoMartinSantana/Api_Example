using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{

    //le paso la entidad que utiliza la bd.
    public class BeerRepository : IRepository<Beer>
    {
        private StoreContext _Context;

        public BeerRepository(StoreContext context)
        {
            _Context = context;
        }

        public async Task Add(Beer entity)
        => await _Context.Beers.AddAsync(entity);

        public void Delete(Beer entity)
        => _Context.Beers.Remove(entity);
        

        public async Task<IEnumerable<Beer>> Get()
            => await _Context.Beers.ToListAsync<Beer>();


        public async Task<Beer> GetById(int id)
            => await _Context.Beers.FindAsync(id);




        public async Task Save()
        => await _Context.SaveChangesAsync();
           
        

        public void Update(Beer entity)
        {
            _Context.Beers.Attach(entity); // ADJUNTA LA ENTIDAD A MI CONTEXTO
            _Context.Beers.Entry(entity).State = EntityState.Modified; // hacemos una entrada de esa entidad y definimos su estado como modificado. para que el save change shaga algo.

        }
    }
}
