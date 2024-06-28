namespace ShoesApp.Interfaces
{
    /// <summary>
    /// Servizio per la gestione delle immagini.
    /// </summary>
    public interface IImgService
    {
        /// <summary>
        /// Salva un'immagine sul server.
        /// </summary>
        /// <param name="image">L'immagine da salvare, ricevuta come file tramite un form.</param>
        /// <param name="imageName">Il nome da assegnare all'immagine salvata.</param>
        /// <param name="imageType">Il tipo dell'immagine (es. "profilo", "copertina") per categorizzare l'immagine.</param>
        /// <returns>Il percorso relativo dell'immagine salvata, che può essere utilizzato per costruire l'URL di accesso all'immagine.</returns>
        string SaveImage(IFormFile image, string imageName, string imageType);

        /// <summary>
        /// Restituisce l'URL di un'immagine.
        /// </summary>
        /// <param name="imageName">Il nome dell'immagine per cui ottenere l'URL.</param>
        /// <param name="imageType">Il tipo dell'immagine (es. "profilo", "copertina") per categorizzare l'immagine.</param>
        /// <returns>L'URL completo per accedere all'immagine. Può essere utilizzato per incorporare l'immagine in una pagina web o per fornire un link diretto.</returns>
        string GetImageUrl(string imageName, string imageType);
    }
}
