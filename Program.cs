using Microsoft.Extensions.Options;
using MovieMagic.Models;
using MovieMagic.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MovieDatabaseSettings>(builder.Configuration.GetSection("MovieDatabaseSettings"));
builder.Services.AddSingleton<IMovieDatabaseSettings>(s => s.GetRequiredService<IOptions<MovieDatabaseSettings>>().Value);
builder.Services.AddScoped<IMovieRepository, MongoMovieRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
