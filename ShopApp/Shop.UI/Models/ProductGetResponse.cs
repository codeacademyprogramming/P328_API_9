namespace Shop.UI.Models
{
    public class ProductGetResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ImageUrl { get; set; }
        public BrandInProductGetResponse Brand { get; set; }
    }

    public class BrandInProductGetResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
