using System;
using Microsoft.EntityFrameworkCore;
using tut.Data;
using tut.Dtos;
using tut.Entities;
using tut.Mapping;

namespace tut.Endpoints;

public static class MoviesEndpoints
{
    const string GetMovieEnpointName = "GetMovie";

    public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("movies").WithParameterValidation();

        // GET /movies
        group.MapGet("/", async (MovieStoreContext dbContext) => 
        {
            return await dbContext.Movies.Include(movie => movie.Genre).Select(movie => movie.ToMovieSummaryDto()).AsNoTracking().ToListAsync();
        });

        //GET /games/id/x
        group.MapGet("/id/{id}", async (int id, MovieStoreContext dbContext) =>
        {
            Movie? movie = await dbContext.Movies.FindAsync(id);

            return movie is null ? Results.NotFound() : Results.Ok(movie!.ToMovieDetailsDto());

        }).WithName(GetMovieEnpointName);
        
        //GET /games/name/x
        group.MapGet("/name/{name}", async (string name, MovieStoreContext dbContext) =>
        {
            return await dbContext.Movies.Where(movie => movie.Name.ToLower().Contains(name.ToLower())).Include(movie => movie.Genre).Select(movie => movie.ToMovieSummaryDto()).ToListAsync();
        });
        //Get /games/genre/x
        group.MapGet("/genre/{genreId}", async (int genreId, MovieStoreContext dbContext) =>
        {
            return await dbContext.Movies.Where(movie => movie.Genre!.Id == genreId).Select(movie => movie.ToMovieDetailsDto()).ToListAsync();
        });

        //POST /movies
        group.MapPost("/", async (CreateMovieDto newMovie, MovieStoreContext dbContext) => 
        {
            Movie movie = newMovie.ToEntity();

            dbContext.Movies.Add(movie);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetMovieEnpointName, new {id = movie.Id}, movie.ToMovieDetailsDto());
        });

        //PUT /movies/x
        group.MapPut("/{id}", async (int id, UpdateMovieDto updatedMovie, MovieStoreContext dbContext) => 
        {
            var existingMovie = await dbContext.Movies.FindAsync(id);

            if(existingMovie is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingMovie).CurrentValues.SetValues(updatedMovie.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /movies/x

        group.MapDelete("/{id}", async (int id, MovieStoreContext dbContext) =>
        {
            await dbContext.Movies.Where(movie => movie.Id == id).ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
