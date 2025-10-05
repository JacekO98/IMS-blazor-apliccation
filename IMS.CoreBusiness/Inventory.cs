using System.ComponentModel.DataAnnotations;

/// Jest to klasa do tworzenia obiektów w magazynie
namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        /// Poniżej jest warunek, że imie jest wymagane i maksymalna długość to 150 znaków
        [Required]
        [StringLength(150)]
        public string InventoryName { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0. ")]
        /// Powyżej jest warunek, że ilość nie może być pusta (moim zdaniem powinna być wiekszą niż 1 ale chce mieć tak samo żeby nie mieszać w kodzie
        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater or equal to 0. ")]
        public double Price { get; set; }

    }
}
