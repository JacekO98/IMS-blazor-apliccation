using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
/// Tutaj tworzę repozytorium czyli takiego pośrednika pomiędzy aplikacją a bazą danych. 
/// To działa jak savingData(account_list, PLIKZAPISOWY) w BankAccount w pythonie.
/// zamiast tworzyć to w jednym pliku tworzę osobną strukturę
namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2},
                new Inventory { InventoryId = 2, InventoryName = "Bike Body", Quantity = 10, Price = 15},
                new Inventory { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 8},
                new Inventory { InventoryId = 4, InventoryName = "Bike Pedels", Quantity = 20, Price = 1},
            };
        }

        public Task AddInventoryAsync(Inventory inventory)
        ///Task to obiekt w C#, który reprezentuje trwające (lub przyszłe) zadanie — coś, co wykonuje się asynchronicznie, czyli w tle.
        {
            if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase))) 
            { return Task.CompletedTask; }
            ///Any() to metoda LINQ Zwraca true albo false
            ///x => x to wyrażenie to lambda tak samo jak w pythonie
            ///Ordinal oznacza, że porównanie odbywa się na podstawie kodów znaków (szybkie porównanie binarne). IgnoreCase oznacza, że ignoruje wielkość liter.
            ///return Task.CompletedTask - oznacza „Zakończ metodę natychmiast — nie rób już nic więcej.”(czyli nie dodawaj nowego elementu do listy).
            var maxId = _inventories.Max(x => x.InventoryId);
            /// Sprawdzam największy ID jakie obecnie wystepuje
            inventory.InventoryId = maxId + 1;
            /// dodaje do największego Id 1 i je nadaje nowemu recordowi
            _inventories.Add(inventory);

            
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_inventories);
            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
