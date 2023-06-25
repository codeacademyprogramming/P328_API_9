namespace Shop.Services.Dtos.ProductDtos
{
    public class ProductGetAllItemDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal SalePrice { get; set; }
        public bool HasDiscount { get; set; }
        public string ImageUrl { get; set; }
    }
}
