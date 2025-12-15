using Dapper;
using MachineWeb.DAL;
using MachineWeb.Models;
using static MachineWeb.Models.UserLogin;

namespace MachineWeb.BAL
{
  
    public class UserLoginService
    {
        private readonly IConfiguration _configuration;
        public UserLoginService(IConfiguration aconfiguration)
        {
            this._configuration = aconfiguration;
        }
        public async Task<CommonResponseDto<UserResponseDto>> Login(string UserName, string Password)
        {
            UserResponseDto res = new UserResponseDto();
            string _proc = "Proc_Login";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@UserName", UserName);
            queryparameter.Add("@Password", Password);
            res = await DBHelperDapper.GetAddResponseModel<UserResponseDto>(_proc, queryparameter);
            if (res != null && res.UserGuid != Guid.Empty)
            {
                return new CommonResponseDto<UserResponseDto>
                {
                    Data = res,
                    Flag = 1,
                    Message = "Login Successful"
                };

            }
            else
            {
                return new CommonResponseDto<UserResponseDto>
                {
                    Data = null,
                    Flag = 0,
                    Message = "Invalid Credentials"
                };
            }
        }
    }
}
