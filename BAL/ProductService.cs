using Dapper;
using MachineWeb.DAL;
using MachineWeb.Models;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace MachineWeb.BAL
{
    public class ProductService
    {
        private readonly IConfiguration _configuration;
        public ProductService(IConfiguration aconfiguration)
        {
            this._configuration = aconfiguration;
        }
        public async Task<CommonResponseDto<_productresdto>> SaveProduct(CommonRequestDto<ProductRequestDto> requestDto, DataTable images)
        {
            var response = new CommonResponseDto<_productresdto>();

            var data = requestDto.Data;

            string _proc = "Proc_SaveProduct";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", 1);
            queryparameter.Add("@CategoryId", data.CategoryId);
            queryparameter.Add("@ProductName", data.ProductName);
            queryparameter.Add("@Description", data.Description);
            queryparameter.Add("@ShortDescription", data.ShortDescription);
            queryparameter.Add("@IsActive", data.IsActive);
            queryparameter.Add("@DelMark", data.DelMark);
            queryparameter.Add("@Remarks", data.Remarks);
            queryparameter.Add("@IsShowOnWeb", data.IsShowOnWeb);
            queryparameter.Add("@CreatedBy", requestDto.UserId);
            queryparameter.Add("@ProductImages", images.AsTableValuedParameter("dbo.ProductImageType"));




            var res = await DBHelperDapper.GetAddResponseModel<_productresdto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }


        public async Task<CommonResponseDto<_productresdto>> UpdateProduct(CommonRequestDto<ProductRequestDto> requestDto,DataTable images)
        {
            var response = new CommonResponseDto<_productresdto>();

            var data = requestDto.Data;

            string _proc = "Proc_SaveProduct";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", 2);
            queryparameter.Add("@ProductGuid", data.ProductGuid);
            queryparameter.Add("@CategoryId", data.CategoryId);
            queryparameter.Add("@ProductName", data.ProductName);
            queryparameter.Add("@Description", data.Description);
            queryparameter.Add("@ShortDescription", data.ShortDescription);
            queryparameter.Add("@IsActive", data.IsActive);
            queryparameter.Add("@DelMark", data.DelMark);
            queryparameter.Add("@Remarks", data.Remarks);
            queryparameter.Add("@IsShowOnWeb", data.IsShowOnWeb);
            queryparameter.Add("@CreatedBy", requestDto.UserId);
            queryparameter.Add("@ProductImages", images.AsTableValuedParameter("dbo.ProductImageType"));
            var res = await DBHelperDapper.GetAddResponseModel<_productresdto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<ProductResponseDto>>> GetListService(CommonRequestDto<ProductSearchDto> commonRequest)
        {

            var response = new CommonResponseDto<List<ProductResponseDto>>();
            string proc = "Proc_SaveProduct";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcedureId", 3);
            queryParameter.Add("@ProductName", commonRequest.Data.ProductName ?? "");
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);
            var res = await DBHelperDapper.GetPagedModelList<ProductResponseDto>(proc, queryParameter);

            return res;
        }

        public async Task<CommonResponseDto<ProductResponseDto>> GetProductService(CommonRequestDto<ProductRequestDto> commonRequest)
        {
            var response = new CommonResponseDto<ProductResponseDto>();
            string proc = "proc_GetProduct";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcedureId", 4);
            queryParameter.Add("@ProductGuid", commonRequest.Data.ProductGuid);

            var res = DBHelperDapper.GetResponseModel<ProductResponseDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<_productresdto>> DeleteProductImage(CommonRequestDto<string> requestDto)
        {
            var response = new CommonResponseDto<_productresdto>();

            var data = requestDto.Data;

            string _proc = "Proc_SaveProduct";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcedureId", 4);
            queryparameter.Add("@ProductImageGuid", Guid.Parse(requestDto.Data));
            queryparameter.Add("@CreatedBy", requestDto.UserId);





            var res = await DBHelperDapper.GetAddResponseModel<_productresdto>(_proc, queryparameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}
