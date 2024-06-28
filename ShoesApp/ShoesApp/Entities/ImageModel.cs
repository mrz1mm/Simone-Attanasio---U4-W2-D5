using System.ComponentModel.DataAnnotations;

namespace ShoesApp.Entities
{
    /// <summary>
    /// Classe che rappresenta un'immagine
    /// </summary>
    public class ImageModel
    {
        /// <summary>
        /// Nome dell'immagine
        /// </summary>
        [Display(Name = "File")]
        public IFormFile? File { get; set; }
        /// <summary>
        /// URL dell'immagine
        /// </summary>
        public string? Url { get; set; }
    }
}
