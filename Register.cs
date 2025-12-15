using MachineWeb.BAL;

namespace MachineWeb
{
    public static class Register
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<UserLoginService>();
        }
    }
}
