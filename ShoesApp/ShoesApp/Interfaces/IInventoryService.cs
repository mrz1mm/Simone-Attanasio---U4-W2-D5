using ShoesApp.Entities;

namespace ShoesApp.Interfaces
{
/// <summary>
/// Servizio per la gestione dell'inventario
/// </summary>
    public interface IInventoryService : ICrudService<TennisShoes>
    {
        /// <summary>
        /// Restituisce tutti i prodotti presenti in inventario
        /// </summary>
        /// <returns>L'elenco di tutte le scarpe</returns>
        IEnumerable<TennisShoes> GetAllShoes();
    }
}
