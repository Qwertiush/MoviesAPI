using System;
using tut.Dtos;
using tut.Entities;

namespace tut.Mapping;

public static class MovieMapping
{
    public static Movie ToEntity(this CreateMovieDto movie)
    {
        return new Movie()
            {
                Name = movie.Name,
                GenreId = movie.GenreId,
                ReleaseDate = movie.ReleaseDate
            };
    }

    public static Movie ToEntity(this UpdateMovieDto movie, int id)
    {
        return new Movie()
            {
                Id = id,
                Name = movie.Name,
                GenreId = movie.GenreId,
                ReleaseDate = movie.ReleaseDate
            };
    }

    public static MovieSummaryDto ToMovieSummaryDto(this Movie movie)
    {    
        return new(
            movie.Id,
            movie.Name,
            movie.Genre!.Name,
            movie.ReleaseDate
        );
    }

    public static MovieDetailsDto ToMovieDetailsDto(this Movie movie)
    {    
        return new(
            movie.Id,
            movie.Name,
            movie.GenreId,
            movie.ReleaseDate
        );
    }
}
