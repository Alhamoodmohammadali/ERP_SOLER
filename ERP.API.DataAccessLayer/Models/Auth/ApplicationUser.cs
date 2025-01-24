using Microsoft.AspNetCore.Identity;

namespace ERP.API.DataAccessLayer.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? TenantID { get; set; }
    }
}