namespace ProductStore.Models
{
    public class UpdateProductDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; }

        public int? UnitsInStock { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}
