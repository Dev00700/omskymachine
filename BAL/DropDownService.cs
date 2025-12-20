using Dapper;
using MachineWeb.DAL;
using MachineWeb.Models;

namespace MachineWeb.BAL
{
    public class DropDownService
    {
        public async Task<CommonResponseDto<List<DropDownDto>>> BindDropDown(CommonRequestDto<DropDownReq> commonRequest)
        {
            var response = new CommonResponseDto<List<DropDownDto>>();
            string _proc = "Proc_BindDropDown";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", commonRequest.Data.ProcId);
            queryparameter.Add("@ParentId", commonRequest.Data.ParentId);
            var res = await DBHelperDapper.GetResponseModelList<DropDownDto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}
