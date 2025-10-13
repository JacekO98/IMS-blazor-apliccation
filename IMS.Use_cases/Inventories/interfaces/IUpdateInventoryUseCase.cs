using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.interfaces
{
    public interface IUpdateInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}