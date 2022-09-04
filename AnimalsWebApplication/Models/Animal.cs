using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsWebApplication.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int Age { get; set; }
        public string? PictureSrc { get; set; }

        [MaxLength(270, ErrorMessage = "{0} is too long, maximum length is {1} characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(1, int.MaxValue, ErrorMessage = "please choose category")]
        public int CategoryId { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public Category? Category { get; set; }

    }
}
