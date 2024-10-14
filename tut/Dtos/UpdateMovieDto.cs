namespace tut.Dtos;
using System.ComponentModel.DataAnnotations;

public record class UpdateMovieDto(
    [Required][StringLength(50)] string Name, 
    [Required] int GenreId, 
    [Required] DateOnly ReleaseDate
    );
