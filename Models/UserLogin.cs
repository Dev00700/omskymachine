namespace MachineWeb.Models
{
    public class UserLogin
    {
        public class UserLoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class UserResponseDto
        {
            public int UserId { get; set; }
            public Guid UserGuid { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
        }
    }
}
