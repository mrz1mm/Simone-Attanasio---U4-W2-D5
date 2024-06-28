using System.ComponentModel.DataAnnotations;

namespace ShoesApp.Entities
{
    /// <summary>
    /// Classe che rappresenta una scarpa da tennis
    /// </summary>
    public class TennisShoes : BaseEntity
    {
        /// <summary>
        /// Nome della scarpa
        /// </summary>
        [Required(ErrorMessage = "Il nome è obbligatorio.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Descrizione della scarpa
        /// </summary>
        [Required(ErrorMessage = "La descrizione è obbligatoria.")]
        [StringLength(500, ErrorMessage = "La descrizione non può superare i 500 caratteri.")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Prezzo della scarpa
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Immagine di copertina della scarpa
        /// </summary>
        [Display(Name = "Cover")]
        public ImageModel Cover { get; set; } = new ImageModel();

        /// <summary>
        /// Immagine aggiuntiva della scarpa
        /// </summary>
        [Display(Name = "Immagine n° 2")]
        public ImageModel Image1 { get; set; } = new ImageModel();

        /// <summary>
        /// Immagine aggiuntiva della scarpa
        /// </summary>
        [Display(Name = "Immagine n° 3")]
        public ImageModel Image2 { get; set; } = new ImageModel();
    }
}
