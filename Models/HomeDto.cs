namespace MachineWeb.Models
{
    public class HomeRequestDto
    {
        public int ProcId { get; set; }
    }
    public class HomeDto
    {
        public List<ProductDataResponse> productDataResponses { get;set; }
    }
    public class ProductDataResponse
    {
        public Guid ProductGuid { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
    }
}
