namespace ERP.API.BusinessLayer.Service.ServiceAuth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;
        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

            // إنشاء قائمة الـ claims الأساسية
            var claimList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName)
            };
            // إضافة TenantID إلى claims إذا كان موجودًا
            if (!string.IsNullOrEmpty(applicationUser.TenantID))
            {
                claimList.Add(new Claim("TenantID", applicationUser.TenantID));
            }
            else
            {
                // في حالة عدم وجود TenantID، يمكنك إضافة claim فارغ أو تجاهله
                claimList.Add(new Claim("TenantID", string.Empty));  // أو يمكن تجاهل هذا السطر
            }

            // إضافة الأدوار (roles) إلى claims
            claimList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            // إعداد خصائص الـ Token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            // إنشاء الـ JWT Token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
