namespace MachineWeb.Models
{
    public class BlogRequestDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<IFormFile> images { get; set; }
        public string Image { get; set; }
        public string BlogGuid { get; set; }
    }


    public class BlogResponseDto: BaseDto
    {
        public Guid BlogGuid { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }


    }
    public class BlogSearchDto
    {
        public string Title { get; set; }
    }

    public class _Blogresdto
    {
        public int BlogId { get; set; }
        public int Flag { get; set; }
        public string Message { get; set; }
    }
}
