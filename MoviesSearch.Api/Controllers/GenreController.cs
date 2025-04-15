using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesSearch.Api.Entites;
using MoviesSearch.Api.Repositories;

namespace MoviesSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly ISQLGenreRepository _genreRepository;
        private readonly ILogger<GenreController> _logger;
        public GenreController(ISQLGenreRepository sQLGenreRepository,ILogger<GenreController> logger) {

            this._genreRepository = sQLGenreRepository;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetAllGenre")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("method called");
          
            //try
            //{
                var result = _genreRepository.GetList();

                var genres1 = new List<Genres>();

                foreach (var enre in result)
                {
                    genres1.Add(new Genres
                    {
                        genre = enre.Genre1
                    });

                }
            //for (var i = 0; i < result.Count + 1; i++)
            //{
            //    var data = result[i];
            //}

            return Ok(genres1);
            //}
            //catch (Exception ex)
            //{
                
            //}

        }
    }
}
