using Dapper;
using MachineWeb.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MachineWeb.DAL
{
    public class DBHelperDapper
    {
        private static string connectionString = string.Empty;
        public static string connection()
        {
            try
            {
                return connectionString = "Server=68.178.164.44,1437\\DIVIKA;Database=OMSky;User Id=sa;Password=M@tpuchbha!@213$;TrustServerCertificate=true;";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<TClass> GetAddResponseModel<TClass>(string procName, DynamicParameters param)
        {
            try
            {
                using (SqlConnection objConnection = new SqlConnection(connection()))
                {
                    await objConnection.OpenAsync();
                    var result = await objConnection.QueryFirstOrDefaultAsync<TClass>(
                        procName,
                        param,
                        commandType: System.Data.CommandType.StoredProcedure
                    );
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<List<T>> GetResponseModelList<T>(string spName, DynamicParameters p)
        {
            List<T> recordList = new List<T>();
            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                recordList = SqlMapper.Query<T>(objConnection, spName, p, commandType: System.Data.CommandType.StoredProcedure).ToList();
                objConnection.Close();
            }
            return recordList;
        }
        public static T GetResponseModel<T>(string spName, DynamicParameters p)
        {
            try
            {
                var paramLog = GetDynamicParametersLog(p);
                Console.WriteLine($"SP: {spName}\nParameters:\n{paramLog}\nError: ");
                using (SqlConnection objConnection = new SqlConnection(connection()))
                {
                    objConnection.Open();
                    var record = SqlMapper.QueryFirst<T>(
                        objConnection,
                        spName,
                        p,
                        commandType: CommandType.StoredProcedure
                    );
                    return record;
                }
            }
            catch (Exception ex)
            {
                var paramLog = GetDynamicParametersLog(p);
                Console.WriteLine($"SP: {spName}\nParameters:\n{paramLog}\nError: {ex.Message}");

                // Exception को caller तक पहुंचाना ज़रूरी है
                throw;
            }
        }


        public static TResponse GetAllModelNew<TRequest, TResponse>(string procName, DynamicParameters param)
        {
            TResponse result;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    result = SqlMapper.Query<TResponse>(con, procName, param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static T GetModelFromJson<T>(string spName, DynamicParameters p)
        {
            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                var json = objConnection.QueryFirstOrDefault<string>(spName, p, commandType: System.Data.CommandType.StoredProcedure);
                objConnection.Close();
                if (!string.IsNullOrEmpty(json))
                {
                    return System.Text.Json.JsonSerializer.Deserialize<T>(json);
                }
                return default;
            }
        }

        public static async Task<CommonResponseDto<List<T>>> GetPagedModelList<T>(
            string spName,
            DynamicParameters parameters)
        {
            var response = new CommonResponseDto<List<T>>();

            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                using (var multi = objConnection.QueryMultiple(spName, parameters, commandType: CommandType.StoredProcedure))
                {
                    var dataList = multi.Read<T>().ToList();
                    var pageInfo = multi.ReadFirstOrDefault<PageInfoDto>();

                    response.Data = dataList;
                    response.PageSize = pageInfo?.PageSize ?? 1;
                    response.PageRecordCount = pageInfo?.PageRecordCount ?? 10;
                    response.TotalRecordCount = pageInfo?.TotalRecordCount ?? dataList.Count;
                    response.Flag = 1;
                    response.Message = "Success";
                }
            }

            return response;
        }

        public static string GetDynamicParametersLog(DynamicParameters p)
        {
            var sb = new StringBuilder();
            foreach (var name in p.ParameterNames)
            {
                var value = p.Get<dynamic>(name);
                sb.AppendLine($"{name} = {value ?? "NULL"}");
            }
            return sb.ToString();
        }
    }
}
