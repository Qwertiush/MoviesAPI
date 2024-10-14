using System;
using tut.Dtos;
using tut.Entities;

namespace tut.Mapping;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre)
    {
        return new GenreDto(genre.Id,genre.Name);
    }
}
