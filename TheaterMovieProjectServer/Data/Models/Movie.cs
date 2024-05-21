using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheaterMovieProjectServer.Data.Models
{
    [Table("Movies")]
    [Index(nameof(Name))]
    public class Movie
    {
        #region Properties
        [Key]
        [Required]
        public int MovieId { get; set; }
        
        public required string Name { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Theater))]
        public int TheaterId { get; set; }

        #endregion

        #region Navigation Properties
        public Theater? Theater { get; set; }
        #endregion
    }
}
