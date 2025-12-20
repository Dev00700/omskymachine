using Dapper;
using MachineWeb.DAL;
using MachineWeb.Models;
using static MachineWeb.Models.UserLogin;

namespace MachineWeb.BAL
{
    public class CategoryService
    {
        private readonly IConfiguration _configuration;
        public CategoryService(IConfiguration aconfiguration)
        {
            this._configuration = aconfiguration;
        }
        public async Task<CommonResponseDto<_categresdto>> SaveCategory(CommonRequestDto<CategoryRequestDto> requestDto)
        {
            var response = new CommonResponseDto<_categresdto>();

            var data = requestDto.Data;

            string _proc = "Proc_SaveCategory";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", 1);
            queryparameter.Add("@CategoryName", data.CategoryName);
            queryparameter.Add("@CategoryImage", data.Image);
            queryparameter.Add("@IsActive", data.IsActive);
            queryparameter.Add("@DelMark", data.DelMark);
            queryparameter.Add("@Remarks", data.Remarks);
            queryparameter.Add("@CreatedBy", requestDto.UserId);
            var res = await DBHelperDapper.GetAddResponseModel<_categresdto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }


        public async Task<CommonResponseDto<_categresdto>> UpdateCategory(CommonRequestDto<CategoryRequestDto> requestDto)
        {
            var response = new CommonResponseDto<_categresdto>();

            var data = requestDto.Data;

            string _proc = "Proc_SaveCategory";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", 2);
            queryparameter.Add("@CategoryName", data.CategoryName);
            queryparameter.Add("@CategoryGuid", data.CategoryGuid);
            queryparameter.Add("@CategoryImage", data.Image);
            queryparameter.Add("@IsActive", data.IsActive);
            queryparameter.Add("@DelMark", data.DelMark);
            queryparameter.Add("@Remarks", data.Remarks);
            queryparameter.Add("@CreatedBy", requestDto.UserId);
            var res = await DBHelperDapper.GetAddResponseModel<_categresdto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }



        public async Task<CommonResponseDto<List<CategoryResponseDto>>> GetListService(CommonRequestDto<CategorySearchDto> commonRequest)
        {

            var response = new CommonResponseDto<List<CategoryResponseDto>>();
            string proc = "Proc_SaveCategory";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcedureId", 3);
            queryParameter.Add("@CategoryName", commonRequest.Data.CategoryName ?? "");
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);
            var res = await DBHelperDapper.GetPagedModelList<CategoryResponseDto>(proc, queryParameter);

            return res;
        }

        public async Task<CommonResponseDto<CategoryResponseDto>> GetCategoryService(CommonRequestDto<CategoryRequestDto> commonRequest)
        {
            var response = new CommonResponseDto<CategoryResponseDto>();
            string proc = "proc_GetCategory";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcedureId", 4);  
            queryParameter.Add("@CategoryGuid", commonRequest.Data.CategoryGuid);

            var res = DBHelperDapper.GetResponseModel<CategoryResponseDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}
