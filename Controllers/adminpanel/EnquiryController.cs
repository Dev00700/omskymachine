using MachineWeb.BAL;
using MachineWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineWeb.Controllers.adminpanel
{
    public class EnquiryController : Controller
    {

        private readonly EnquiryService _enquiryService;
        public EnquiryController(EnquiryService aenquiryService)
        {
            this._enquiryService = aenquiryService;
        }
        public async Task<IActionResult> Index()
        {
            CommonRequestDto<EnquirySearchDto> requestDto = new CommonRequestDto<EnquirySearchDto>
            {
                CompanyId = 1,
                UserId = 1,
                PageSize = 1,
                PageRecordCount = 100,
                Data = new EnquirySearchDto
                {
                    Name = ""
                }
            };

            var res = await _enquiryService.GetListService(requestDto);

            if (res.Data.Count() > 0)
            {
                return View(res.Data);
            }
            return View(null);
        }
    }
}
