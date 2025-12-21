using Dapper;
using MachineWeb.DAL;
using MachineWeb.Models;

namespace MachineWeb.BAL
{
    public class HomeService
    {
        public async Task<CommonResponseDto<List<ProductDataResponse>>> GetHomeData(CommonRequestDto<HomeRequestDto> commonRequest)
        {
            var response = new CommonResponseDto<List<ProductDataResponse>>();
            string _proc = "Proc_GetHomeData";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", commonRequest.Data.ProcId);
            var res = await DBHelperDapper.GetResponseModelList<ProductDataResponse>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<CategoryDataResponse>>> GetCategoryHomeData(CommonRequestDto<HomeRequestDto> commonRequest)
        {
            var response = new CommonResponseDto<List<CategoryDataResponse>>();
            string _proc = "Proc_GetHomeData";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", commonRequest.Data.ProcId);
            var res = await DBHelperDapper.GetResponseModelList<CategoryDataResponse>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<CategoryWiseProductDataResponse>>> GetCategoryWiseProductData(CommonRequestDto<ProductDetailRequestDto> commonRequest)
        {
            var response = new CommonResponseDto<List<CategoryWiseProductDataResponse>>();
            string _proc = "Proc_GetHomeData";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", commonRequest.Data.ProcId);
            queryparameter.Add("@CategoryGuid", commonRequest.Data.CategoryGuid);
            var res = await DBHelperDapper.GetResponseModelList<CategoryWiseProductDataResponse>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}
