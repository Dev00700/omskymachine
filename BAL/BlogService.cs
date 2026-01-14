using Dapper;
using MachineWeb.DAL;
using MachineWeb.Models;
using static MachineWeb.Models.UserLogin;

namespace MachineWeb.BAL
{
    public class BlogService
    {
        private readonly IConfiguration _configuration;
        public BlogService(IConfiguration aconfiguration)
        {
            this._configuration = aconfiguration;
        }
        public async Task<CommonResponseDto<_Blogresdto>> SaveBlog(CommonRequestDto<BlogRequestDto> requestDto)
        {
            var response = new CommonResponseDto<_Blogresdto>();

            var data = requestDto.Data;

            string _proc = "Proc_SaveBlog";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", 1);
            queryparameter.Add("@Title", data.Title);
            queryparameter.Add("@Description", data.Description);
            queryparameter.Add("@Link", data.Link);
            queryparameter.Add("@Image", data.Image);
            queryparameter.Add("@IsActive", data.IsActive);
            queryparameter.Add("@DelMark", data.DelMark);
            queryparameter.Add("@Remarks", data.Remarks);
            queryparameter.Add("@CreatedBy", requestDto.UserId);
            var res = await DBHelperDapper.GetAddResponseModel<_Blogresdto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }


        public async Task<CommonResponseDto<_Blogresdto>> UpdateBlog(CommonRequestDto<BlogRequestDto> requestDto)
        {
            var response = new CommonResponseDto<_Blogresdto>();

            var data = requestDto.Data;

            string _proc = "Proc_SaveBlog";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", 2);
            queryparameter.Add("@Title", data.Title);
            queryparameter.Add("@Description", data.Description);
            queryparameter.Add("@Link", data.Link);
            queryparameter.Add("@BlogGuid", data.BlogGuid);
            queryparameter.Add("@Image", data.Image);
            queryparameter.Add("@IsActive", data.IsActive);
            queryparameter.Add("@DelMark", data.DelMark);
            queryparameter.Add("@Remarks", data.Remarks);
            queryparameter.Add("@CreatedBy", requestDto.UserId);
            var res = await DBHelperDapper.GetAddResponseModel<_Blogresdto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }



        public async Task<CommonResponseDto<List<BlogResponseDto>>> GetListService(CommonRequestDto<BlogSearchDto> commonRequest)
        {

            var response = new CommonResponseDto<List<BlogResponseDto>>();
            string proc = "Proc_SaveBlog";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcedureId", 3);
            queryParameter.Add("@Title", commonRequest.Data.Title ?? "");
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);
            var res = await DBHelperDapper.GetPagedModelList<BlogResponseDto>(proc, queryParameter);

            return res;
        }

        public async Task<CommonResponseDto<BlogResponseDto>> GetBlogService(CommonRequestDto<BlogRequestDto> commonRequest)
        {
            var response = new CommonResponseDto<BlogResponseDto>();
            string proc = "proc_GetBlog";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcedureId", 4);  
            queryParameter.Add("@BlogGuid", commonRequest.Data.BlogGuid);

            var res = DBHelperDapper.GetResponseModel<BlogResponseDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}
