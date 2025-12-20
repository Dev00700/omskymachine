namespace MachineWeb.Models
{
    public class CommonResponseDto<T>
    {
        public int? CompanyId { get; set; }
        public int PageSize { get; set; }
        public int PageRecordCount { get; set; }
        public int? TotalRecordCount { get; set; }
        public T Data { get; set; } 
        public int Flag { get; set; }
        public string Message { get; set; }
    }

    public class PageInfoDto
    {
        public int PageSize { get; set; }
        public int PageRecordCount { get; set; }
        public int? TotalRecordCount { get; set; }

    }

    public class CommonRequestDto
    {
        public int? CompanyId { get; set; }
        public int PageSize { get; set; }
        public int PageRecordCount { get; set; }
        public long UserId { get; set; }

    }
    public class CommonRequestDto<T> : CommonRequestDto where T : class
    {
        public T? Data { get; set; }
    }

       public class BaseDto
    {
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public bool DelMark { get; set; }
        public string? Remarks { get; set; } = "";
    }

}
