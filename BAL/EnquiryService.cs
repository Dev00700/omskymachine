using Dapper;
using MachineWeb.DAL;
using MachineWeb.Models;

namespace MachineWeb.BAL
{
    public class EnquiryService
    {
        private readonly IConfiguration _configuration;
        public EnquiryService(IConfiguration aconfiguration)
        {
            this._configuration = aconfiguration;
        }

        public async Task<CommonResponseDto<_enquiryresdto>> SendEnquiry(CommonRequestDto<EnquiryRequestDto> requestDto)
        {
            var response = new CommonResponseDto<_enquiryresdto>();
            var data = requestDto.Data;
            string _proc = "Proc_SaveEnquiry";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", 1);
            queryparameter.Add("@Name", data.Name);
            queryparameter.Add("@Email", data.Email);
            queryparameter.Add("@Subject", data.Subject);
            queryparameter.Add("@Message", data.Message);
            queryparameter.Add("@CreatedBy", requestDto.UserId);
            queryparameter.Add("@IsActive", true);
            var res = await DBHelperDapper.GetAddResponseModel<_enquiryresdto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
        public async Task<CommonResponseDto<List<EnquiryResponseDto>>> GetListService(CommonRequestDto<EnquirySearchDto> commonRequest)
        {

            var response = new CommonResponseDto<List<EnquiryResponseDto>>();
            string proc = "Proc_SaveEnquiry";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcedureId", 3);
            queryParameter.Add("@Name", commonRequest.Data.Name ?? "");
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);
            var res = await DBHelperDapper.GetPagedModelList<EnquiryResponseDto>(proc, queryParameter);
            return res;
        }
    }
}
