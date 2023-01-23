using Microsoft.EntityFrameworkCore;
using MovieStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Repositories
{
    public class MovieRepository : IRepository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Movie obj)
        {
            if (obj != null)
            {
                _context.Movies.Add(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Movie> Delete(int id)
        {
            var movieInDb = await _context.Movies.FindAsync(id);
            if (movieInDb != null)
            {
                _context.Movies.Remove(movieInDb);
                await _context.SaveChangesAsync();

                return movieInDb;
            }
            return null;
        }


        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public async Task<Movie> GetById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                return movie;
            }
            return null;
        }



        public async Task<Movie> Update(int id, Movie obj)
        {
            var movieInDb = await _context.Movies.FindAsync(id);
            if (movieInDb != null)
            {
                movieInDb.MovieName = obj.MovieName;
                movieInDb.ProductionName = obj.ProductionName;
                movieInDb.ReleaseDate = obj.ReleaseDate;
                movieInDb.GenreId = obj.GenreId;

                _context.Movies.Update(movieInDb);
                await _context.SaveChangesAsync();
                return movieInDb;
            }
            return null;
        }

        public async Task<IEnumerable<Movie>> SearchByGenre(string genreName)
        {
            if (!string.IsNullOrWhiteSpace(genreName))
            {
                var movies = await _context.Movies.Include(g => g.Genre).Where(g => g.Genre.GenreName.Contains(genreName)).ToListAsync();


                return movies;
            }
            return null;
        }
    }
}

