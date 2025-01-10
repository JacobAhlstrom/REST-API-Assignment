namespace DagnysBakeryAPI.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string ArticleNumber { get; set; }
        public decimal PricePerKg { get; set; }
        public SupplierViewModel Supplier{ get; set; }
    }
}