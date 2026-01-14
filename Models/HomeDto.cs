namespace MachineWeb.Models
{
    public class HomeRequestDto
    {
        public int ProcId { get; set; }
    }
    public class HomeDto
    {
        public List<ProductDataResponse> productDataResponses { get;set; }
        public List<CategoryDataResponse> categoryDataResponses { get;set; }
        public List<BlogDataResponse> blogDataResponses { get;set; }
    }
    public class ProductDataResponse
    {
        public Guid ProductGuid { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
    }

    public class CategoryDataResponse
    {
        public Guid CategoryGuid { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
    }

    public class BlogDataResponse
    {
        public Guid BlogGuid { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }


    public  class ProductDetailRequestDto
    {
        public int ProcId { get; set; }
        public Guid CategoryGuid { get; set; }
    }
    public class CategoryWiseProductDataResponse
    {
        public Guid ProductGuid { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string ProductImage { get; set; }
    }
}
