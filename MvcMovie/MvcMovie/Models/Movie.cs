﻿using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public TimeSpan Length { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
}
