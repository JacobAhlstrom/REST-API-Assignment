namespace DagnysBakeryAPI.ViewModels
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; }
        public string ArticleNumber { get; set; }
        public decimal PricePerKg { get; set; }
        public int SupplierId { get; set; }
    }

}