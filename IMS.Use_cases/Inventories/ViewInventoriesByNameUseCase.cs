
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness;
using IMS.UseCases.Inventories;
using IMS.UseCases.PluginInterfaces;
///Pponiżej podaje namespace czyli taki odnośnik do tej klasy
namespace IMS.UseCases.Inventories
{
    /// "public class ViewInventoriesByNameUseCase" 
    /// To klasa odpowiadająca na pytanie „Pokaż mi wszystkie inwentarze (obiekty w magazynie części), których nazwa zawiera dane słowo.”
    public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
    ///tutaj definiuje że interfejs IViewInventoriesByNameUseCase ma dostęp do klasy ViewInventoriesByNameUseCase    
    {
        ///Use Case nie łączy się sam z bazą danych ani z plikiem. 
        ///Korzysta z interfejsu repozytorium, które jest zdefiniowane w warstwie PluginInterfaces.
        /// Poniżej dajemy znać, że w tej klasie wykorzystujemy InventoryRepository czyli metodę komunikującą się z bazą danych.
        /// Mogącą zapisywać i odczytywać rekordy z bazy danych.
        private readonly IInventoryRepository inventoryRepository;

        /// Poniżej mamy konstruktor czyli metodę która będzie przekazywała zależności zeby stworzyć obiekt. 
        /// Jest to tzw. dependency Injection <summary>
        /// IInventoryRepository inventoryRepository poniżej podaje jako argument do funkcji,
        /// która nastepnie przekazuje obiekt do konstruktora "this.inventoryRepository" i później to jako obiekt jest przekazywane do
        /// "private readonly IInventoryRepository inventoryRepository;"
        public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
         {
            this.inventoryRepository = inventoryRepository;
        }

       

        ///Poniżej metoda która odpowiada za wyszukiwanie obiektów po nazwie
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await inventoryRepository.GetInventoriesByNameAsync(name);
        }
    }
}
