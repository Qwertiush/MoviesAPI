namespace tut.Dtos;

public record class MovieDetailsDto(
    int Id, 
    string Name, 
    int GenreId, 
    DateOnly ReleaseDate
);
