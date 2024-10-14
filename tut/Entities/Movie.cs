using System;

namespace tut.Entities;

public class Movie
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public DateOnly ReleaseDate { get; set; }
    
}
