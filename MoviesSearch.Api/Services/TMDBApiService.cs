namespace MoviesSearch.Api.Services
{
    public class TMDBApiService
    {
        private readonly HttpClient _httpClient;

        private readonly string apikey = "2611e0892ed7e953552c3a8ebc1a2b0d";

        public TMDBApiService(HttpClient httpClient)
        {
            this._httpClient = httpClient;

           
                
        }

        public async Task<string> SearchMovieAsync(string query) 
        {
            string baseurl = "https://api.themoviedb.org/3/search/movie";
            string apikey = "2611e0892ed7e953552c3a8ebc1a2b0d";

            string url = $"{baseurl}?query={query}&api_key={apikey}";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content= await response.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetSimilarMovies(int id) 
        {
            string baseurl = $"https://api.themoviedb.org/3/movie/{id}/similar";
            string url = $"{baseurl}?api_key={apikey}";

            var response= await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content=await response.Content.ReadAsStringAsync();

            return content;

        }

        public async Task<string> GetMovieDetails(int id) 
        {
            string baseurl = $"https://api.themoviedb.org/3/movie/";
            string url = $"{baseurl}{id}?api_key={apikey}";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return content;

        }

    }
}
