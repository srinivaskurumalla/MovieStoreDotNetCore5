using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using MovieStore.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<Movie> _repository;

        public MoviesController(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllMovies")]
        public IEnumerable<Movie> GetMovies()
        {
            return _repository.GetAll();
        }

        [HttpGet]
        [Route("GetMovieById/{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _repository.GetById(id);
            if(movie == null) 
            {
            return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }
    }
}
