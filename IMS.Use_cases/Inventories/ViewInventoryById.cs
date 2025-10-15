using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness;
using IMS.UseCases.Inventories.interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories
{
    public class ViewInventoryById : IVievInventoryById
    {
        private readonly IInventoryRepository inventoryRepository;
        public ViewInventoryById(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<Inventory> ExecuteAsync(int inventoryId)
        {
            return await inventoryRepository.GetInventoryByIdAsync(inventoryId);

        }
    }
}
