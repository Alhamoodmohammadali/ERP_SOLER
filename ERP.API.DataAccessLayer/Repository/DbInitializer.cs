namespace ERP.API.DataAccessLayer.Repository
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            // Apply pending migrations if any
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary, e.g., log them
            }

            // Create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                // Create roles for various employees and managers
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_AccountingEmployee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_ManagementEmployee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_RegularEmployee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_WorkshopManager)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_SeniorManager)).GetAwaiter().GetResult();

                // Create admin user if roles are not created
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@ERP.com",
                    Email = "admin@ERP.com",
                    Name = "Bhrugen Patel",
                    PhoneNumber = "1112223333",
                    TenantID = ""
                }, "Admin123*").GetAwaiter().GetResult();


                // Assign the admin role to the created user
                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@ERP.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }

            return;
        }
    }
}
