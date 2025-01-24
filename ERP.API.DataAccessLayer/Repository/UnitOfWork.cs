
namespace ERP.API.DataAccessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        public IAddressRepository Address { get; private set; }
        public ICountryRepository Country { get; private set; }
        public IDistrictRepository District { get; private set; }
        public ICityRepository City { get; private set; }

        public IBudgetRepository Budget { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public IEmployeeAttendanceRepository EmployeeAttendance { get; private set; }
        public IEmployeeRepository Employee { get; private set; }
        public IInvoicesRepository Invoices { get; private set; }
        public IMaintenanceOperationRepository MaintenanceOperation { get; private set; }
        public IPayrollRepository Payroll { get; private set; }
        public IProcurementProductsRepository ProcurementProducts { get; private set; }
        public IProcurementsRepository Procurements { get; private set; }
        public ISalesProductsRepository SalesProducts { get; private set; }
        public ISalesRepository sales { get; private set; }
        public ISupplierRepository Supplier { get; private set; }
        public IWorkshopEmployeeScheduleRepository WorkshopEmployeeSchedule { get; private set; }
        public IWorkshopRepository Workshop { get; private set; }
        public IProductsRepository Products { get; }
        public UnitOfWork(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration));
            Budget = new BudgetRepository(_connectionString);
            Category = new CategoriesRepository(_connectionString);
            Customer = new CustomerRepository(_connectionString);
            EmployeeAttendance = new EmployeeAttendanceRepository(_connectionString);
            Employee = new EmployeeRepository(_connectionString);
            Invoices = new InvoicesRepository(_connectionString);
            MaintenanceOperation = new MaintenanceOperationRepository(_connectionString);
            Payroll = new PayrollRepository(_connectionString);
            ProcurementProducts = new ProcurementProductsRepository(_connectionString);
            Procurements = new ProcurementsRepository(_connectionString);
            sales = new SalesRepository(_connectionString);
            SalesProducts = new SalesProductsRepository(_connectionString);
            Supplier = new SupplierRepository(_connectionString);
            Workshop = new WorkshopRepository(_connectionString);
            WorkshopEmployeeSchedule = new WorkshopEmployeeScheduleRepository(_connectionString);
            Products = new ProductsRepository(_connectionString);
            Address = new AddressRepository(_connectionString);
            City = new CityRepository(_connectionString);
            Country = new CountryRepository(_connectionString);
            District = new DistrictRepository(_connectionString);
            Company = new CompanyRepository(_connectionString);
        }
    }
}
