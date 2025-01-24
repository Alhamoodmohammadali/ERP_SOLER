namespace ERP.API.BusinessLayer.Service.IService.IServiceAuth
{
    public interface IAuthService
    {
        Task<string> Register(RegisterRequestDTO registrationRequestDto);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
