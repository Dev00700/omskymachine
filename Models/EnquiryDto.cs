namespace MachineWeb.Models
{
    public class EnquiryRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
    public class _enquiryresdto
    {
        public int EnquiryId { get; set; }
        public int Flag { get; set; }
        public string Message { get; set; }
    }

    public class EnquirySearchDto
    {
        public string Name { get; set; }
    }
    public class EnquiryResponseDto
    {
        public Guid EnquiryGuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
