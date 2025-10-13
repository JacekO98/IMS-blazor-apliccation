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
    public class UpdateInventoryUseCase : IUpdateInventoryUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public UpdateInventoryUseCase(IInventoryRepository InventoryRepository)
        {
            this.inventoryRepository = InventoryRepository;
        }
        public async Task ExecuteAsync(Inventory inventory)
        {
            await this.inventoryRepository.UpdateAsync(inventory);
        }
    }
}
