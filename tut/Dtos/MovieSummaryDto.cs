namespace tut.Dtos;

public record class MovieSummaryDto(
    int Id, 
    string Name, 
    string Genre, 
    DateOnly ReleaseDate
);
