using System.ComponentModel.DataAnnotations;

namespace MovieMagic.Models{
public class Movie{
    public int MovieId { get; set;}
    [Required]
    public string Name { get; set;}
    [Required]
    [Range(0,5)]
    public int Rating { get; set;}
}

}
