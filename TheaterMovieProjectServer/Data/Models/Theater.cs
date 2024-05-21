using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheaterMovieProjectServer.Data.Models
{
    [Table("Theaters")]
    [Index(nameof(Name))]
    [Index(nameof(Location))]
    public class Theater
    {
        #region Properties

        [Key]
        [Required]
        public int TheaterId { get; set; }
        
        public required string Name {  get; set; }

        public required string Location { get; set; }

        public ICollection<Movie> Movies { get; set; }
        #endregion

    }
}
