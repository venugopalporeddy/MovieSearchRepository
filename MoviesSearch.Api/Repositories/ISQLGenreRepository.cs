
using MoviesSearch.Api.Models;

namespace MoviesSearch.Api.Repositories
{
    public interface ISQLGenreRepository
    {
        List<Genre> GetList();
    }
}
