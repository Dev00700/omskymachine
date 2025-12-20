namespace MachineWeb.Models
{
    public class DropDownDto
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class DropDownReq
    {
        public int? ProcId { get; set; }
        public int? ParentId { get; set; }
        public string? SearchDDL { get; set; }
    }
}
