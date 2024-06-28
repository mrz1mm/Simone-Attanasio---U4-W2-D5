using ShoesApp.Entities;
using ShoesApp.Interfaces;

namespace ShoesApp.Services
{
    public class InventoryService : CrudService<TennisShoes>, IInventoryService
    {
        public IEnumerable<TennisShoes> GetAllShoes() =>
            entities;
    }
}
