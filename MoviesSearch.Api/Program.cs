using Microsoft.EntityFrameworkCore;
using MoviesSearch.Api.Middlewares;
using MoviesSearch.Api.Models;
using MoviesSearch.Api.Repositories;
using MoviesSearch.Api.Services;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

//string keyVaultUri = "https://moviesearchkeyvault.vault.azure.net/";

//// Create a SecretClient using DefaultAzureCredential
//var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

//// Get the secret
//KeyVaultSecret secret = await client.GetSecretAsync("ConnectionStrings");

// Use the connection string
//string connectionString = secret.Value;

// Add services to the container.
builder.Services.AddDbContext<MovieDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
});

builder.Services.AddScoped<ISQLGenreRepository, SQLGenreRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<TMDBApiService>();

builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();


app.CallResponseMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.AddErrorHandler();

//app.UseMiddleware<CustomErrorMiddleware>();

app.CallResponseMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
