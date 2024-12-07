using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }

    [StringLength(65, MinimumLength =1)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Title cannot be empty or whitespace.")]
    [Required]
    public string Title { get; set; }

    [StringLength(300, MinimumLength =5)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Description cannot be empty or whitespace.")]
    [Required]
    public string Description { get; set; }

    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Length cannot be empty or whitespace.")]
    [Required]
    public TimeSpan Length { get; set; }

    [StringLength(25, MinimumLength =3)]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Genre cannot be empty or whitespace.")]
    [Required]
    public string Genre { get; set; }

    [Range(120, 180)]
    [DataType(DataType.Currency)]
    [Column(TypeName ="decimal(18, 2)")]
    [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Price cannot be empty or whitespace.")]
    public decimal Price { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string? Rating { get; set; }

}
