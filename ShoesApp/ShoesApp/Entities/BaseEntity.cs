namespace ShoesApp.Entities
{
    /// <summary>
    /// Entità di base per le entità del dominio
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Identificativo univoco dell'entità
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Data di creazione dell'entità
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
