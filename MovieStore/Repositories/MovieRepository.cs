using MovieStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Movie> Create(Movie obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public async Task<Movie> GetById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if(movie != null)
            {
                return movie;
            }
            return null;
                }

        public Task<Movie> Update(int id, Movie obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
