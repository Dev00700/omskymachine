//using System.Web.Mvc;
using System.Web;
using System.Web.Mvc;

namespace MachineWeb.Models
{
    public class ProductRequestDto : BaseDto
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public List<IFormFile>? images { get; set; } // Make nullable to fix CS8618
        public string Image { get; set; }
        public string ProductGuid { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public bool IsShowOnWeb { get; set; }
    }


    public class ProductResponseDto : BaseDto
    {
        public Guid ProductGuid { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }

        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string ProductImage { get; set; }
        public string ImageUrl { get; set; }
        public bool IsShowOnWeb { get; set; }
        public string ProductImagesJson { get; set; }
        public List<ProductImageDto> productImageDtos { get; set; }


    }
    public class ProductSearchDto
    {
        public string ProductName { get; set; }
    }

    public class _productresdto
    {
        public int ProductId { get; set; }
        public int Flag { get; set; }
        public string Message { get; set; }
    }

    public class ProductImageDto
    {
        public Guid ProductImageGuid { get; set; }
        public string Image { get; set; }
    }
}
