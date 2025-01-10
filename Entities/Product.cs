namespace DagnysBakeryAPI.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ArticleNumber { get; set; }
        public decimal PricePerKg { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}