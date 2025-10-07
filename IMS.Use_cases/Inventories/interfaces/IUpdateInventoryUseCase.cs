using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.interfaces
{
    internal interface IUpdateInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}