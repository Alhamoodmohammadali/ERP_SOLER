namespace ERP.API.BusinessLayer.Service.IService.IServiceAuth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
