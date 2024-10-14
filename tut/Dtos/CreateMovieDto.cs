using System.ComponentModel.DataAnnotations;

namespace tut.Dtos;

public record class CreateMovieDto(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Required] DateOnly ReleaseDate
);
