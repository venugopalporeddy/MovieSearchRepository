using System;
using System.Collections.Generic;

namespace MoviesSearch.Api.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime? Releasedate { get; set; }
        public double? Rating { get; set; }
        public string? Posterurl { get; set; }
    }
}
