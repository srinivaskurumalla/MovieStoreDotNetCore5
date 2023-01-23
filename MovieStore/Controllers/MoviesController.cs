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
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IRepository<Movie> repository,IMovieRepository movieRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("GetAllMovies")]
        public IEnumerable<Movie> GetMovies()
        {
            return _repository.GetAll();
        }

        [HttpGet]
        [Route("GetMovieById/{id}", Name= "GetMovieById")]
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

        [HttpPost("CreateMovie")]
        public async Task<IActionResult> CreateMovie([FromBody] Movie movie)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _repository.Create(movie);
            return CreatedAtRoute("GetMovieById",new {id=movie.Id},movie);
        }

        [HttpPut("UpdateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _repository.Update(id, movie);
            if(result!=null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var res =  await _repository.Delete(id);
            if(res!=null)
            {
                return Ok(res);
            }
            return NotFound("Movie with id "+id +" not available");
        }

        [HttpGet("SearchMovie/{genreName}")]
        public async Task<IActionResult> SearchMovie(string genreName)
        {
            var res = await _movieRepository.SearchByGenre(genreName);

            if(res != null)
            {
                return Ok(res);
            }
            return NotFound("Please provide valid Genre");
        }

    }
}
