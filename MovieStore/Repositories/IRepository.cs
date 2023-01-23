using MovieStore.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        Task<T> GetById(int id);

        Task Create(T obj);
        Task<T> Update(int id,T obj);
        Task<T> Delete(int id);
    }

    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> SearchByGenre(string genreName);
    }
}
