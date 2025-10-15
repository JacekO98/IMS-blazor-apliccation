using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.interfaces
{
    public interface IVievInventoryById
    {
        Task<Inventory> ExecuteAsync(int inventoryId);
    }
}