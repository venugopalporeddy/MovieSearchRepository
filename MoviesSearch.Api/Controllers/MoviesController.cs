using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoviesSearch.Api.Services;
using System.Text.Json;

namespace MoviesSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly TMDBApiService _service;
        public MoviesController(TMDBApiService tMDBApiService)
        {
            this._service = tMDBApiService;
            
        }
        [HttpGet]
        [Route("getmovieslist")]
        public async Task<IActionResult> getmovies([FromQuery] string query) 
        {
            if (string.IsNullOrEmpty(query)) 
            {
                return BadRequest("query parameter is required");
            }

            var results= await _service.SearchMovieAsync(query);
            return Ok(JsonDocument.Parse(results));
            
        }
        [HttpGet]
        [Route("{movieid:int}")]
        public async Task<IActionResult> GetSimilarMovies([FromRoute] int movieid)
        {
            var results = await _service.GetSimilarMovies(movieid);

            return Ok(JsonDocument.Parse(results));
        }

        [HttpGet]
        [Route("GetMovieDetails")]
        public async Task<IActionResult> GetMovieDetails([FromQuery] int movieid) 
        {
            var results= await _service.GetMovieDetails(movieid);
            return Ok(JsonDocument.Parse(results));
        }

        [HttpGet]
        [Route("CheckDeployments")]
        public async Task<IActionResult> CheckDeployments() 
        {
            return Ok("you did it successfully ci / cd check");
        }
    }
}
