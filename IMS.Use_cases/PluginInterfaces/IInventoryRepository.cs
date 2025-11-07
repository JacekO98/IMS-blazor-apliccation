using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task AddInventoryAsync(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
        Task<Inventory> GetInventoryByIdAsync(int inventoryId);
        Task EditInventoryAsync(Inventory inventory);
        Task DeleteInventoryAsync(Inventory inventory);
    }
}
