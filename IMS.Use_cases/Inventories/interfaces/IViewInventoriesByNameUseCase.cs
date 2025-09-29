using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories /// możliwe że tu powinno jeszcze być .interfaces i tak samo w zakładce imports
{
    public interface IViewInventoriesByNameUseCase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}