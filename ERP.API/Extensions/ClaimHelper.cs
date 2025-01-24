namespace ERP.API.Extensions
{
    public class ClaimHelper
    {
        private readonly ClaimsPrincipal _user;

        public ClaimHelper(ClaimsPrincipal user)
        {
            _user = user;
        }

        // دالة لاستخراج UserId
        public (string? UserId, APIResponseDTO? errorResponse) GetUserId()
        {
            var response = new APIResponseDTO();
            var userIdClaim = _user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "User not authorized" };
                return (null, response);
            }
            string? UserId = userIdClaim.Value;

            return (UserId, null);
        }

        // دالة لاستخراج TenantId
        public (string? TenantId, APIResponseDTO? errorResponse) GetTenantId()
        {
            var response = new APIResponseDTO();
            var tenantIdClaim = _user.FindFirst("TenantID");
            if (tenantIdClaim == null)
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "TenantID not found" };
                return (null, response);
            }
            string? TenantId = tenantIdClaim.Value;
            return (TenantId, null);
        }
    }

}
