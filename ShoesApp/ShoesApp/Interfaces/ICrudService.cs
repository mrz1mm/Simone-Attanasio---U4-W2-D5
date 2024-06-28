using ShoesApp.Entities;

namespace ShoesApp.Interfaces
{
    /// <summary>
    /// Interfaccia per i servizi CRUD.
    /// </summary>
    /// <typeparam name="T">Tipo di dato gestito, deve ereditare da BaseEntity.</typeparam>
    public interface ICrudService<T> where T : BaseEntity
    {
        /// <summary>
        /// Crea una nuova entità nel database.
        /// </summary>
        /// <param name="entity">L'entità da creare.</param>
        void Create(T entity);

        /// <summary>
        /// Aggiorna un'entità esistente nel database.
        /// </summary>
        /// <param name="entity">L'entità da aggiornare con i nuovi valori.</param>
        void Update(T entity);

        /// <summary>
        /// Elimina un'entità esistente dal database.
        /// </summary>
        /// <param name="entityId">L'identificativo univoco dell'entità da eliminare.</param>
        void Delete(int entityId);

        /// <summary>
        /// Restituisce un'entità per il suo ID.
        /// </summary>
        /// <param name="entityId">Identificativo univoco dell'entità da recuperare.</param>
        T GetById(int entityId);
    }
}