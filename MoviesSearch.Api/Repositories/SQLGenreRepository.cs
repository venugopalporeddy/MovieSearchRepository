using MoviesSearch.Api.Entites;
using MoviesSearch.Api.Models;

namespace MoviesSearch.Api.Repositories
{
    public class SQLGenreRepository : ISQLGenreRepository
    {
        private readonly MovieDbContext _dbContext;

        public SQLGenreRepository(MovieDbContext movieDbContext) 
        {
            this._dbContext = movieDbContext;

        }
        public List<Genre> GetList()
        {
           var result= _dbContext.Genres.ToList();

            return result;

            
           
        }
    }
}
