namespace MachineWeb.Models
{
    public class CategoryRequestDto : BaseDto
    {
        public string CategoryName { get; set; }
        public List<IFormFile> images { get; set; }
        public string Image { get; set; }
        public string CategoryGuid { get; set; }
    }


    public class CategoryResponseDto: BaseDto
    {
        public Guid CategoryGuid { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public string ImageUrl { get; set; }


    }
    public class CategorySearchDto
    {
        public string CategoryName { get; set; }
    }

    public class _categresdto
    {
        public int CategoryId { get; set; }
        public int Flag { get; set; }
        public string Message { get; set; }
    }
}
