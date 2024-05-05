using SimpleBookCatalogWithControllers.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimpleBookCatalogWithControllers.Shared.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a title")]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please provide the author's name")]
        [StringLength(100)]
        public string? Author { get; set; }


        [Required(ErrorMessage = "Please provide the publication date")]
        public DateTime PublicationDate { get; set; }


        [EnumDataType(typeof(Category), ErrorMessage = "Please select a category")]
        public Category Category { get; set; }

    }
}
