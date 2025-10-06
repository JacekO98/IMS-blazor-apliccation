using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories
{
    internal interface IUpdateInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}