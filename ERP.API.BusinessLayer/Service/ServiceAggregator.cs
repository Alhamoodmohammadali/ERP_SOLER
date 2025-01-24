namespace ERP.API.BusinessLayer.Service
{
    public class ServiceAggregator : IServiceAggregator
    {
        protected readonly ILogger _logger;
        public IAddressService AddressService { get; private set; }
        public ICountryService CountryService { get; private set; }
        public IDistrictService DistrictService { get; private set; }
        public ICityService CityService { get; private set; }
        public IBudgetService BudgetService { get; private set; }
        public ICompanyService CompanyService { get; private set; }
        public ICategoryService CategoriesService { get; private set; }
        public ICustomerService CustomerService { get; private set; }
        public IEmployeeAttendanceService EmployeeAttendanceService { get; private set; }
        public IEmployeeService EmployeeService { get; private set; }
        public IInvoicesService InvoicesService { get; private set; }
        public IMaintenanceOperationService MaintenanceOperationService { get; private set; }
        public IPayrollService PayrollService { get; private set; }
        public IProcurementProductsService ProcurementProductsService { get; private set; }
        public IProcurementsService ProcurementsService { get; private set; }
        public IProductsService ProductsService { get; private set; }
        public ISalesProductsService SalesProductsService { get; private set; }
        public ISupplierService SupplierService { get; private set; }
        public IWorkshopService WorkshopService { get; private set; }
        public IWorkshopEmployeeScheduleService WorkshopEmployeeScheduleService { get; private set; }

        public ISalesService SaleService  { get; private set; }

        // Inject all services through the constructor
        public ServiceAggregator(ILogger<ServiceAggregator> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            AddressService = new AddressService(_logger, unitOfWork);
            CountryService = new CountryService(_logger, unitOfWork);
            DistrictService = new DistrictService(_logger, unitOfWork);
            CityService = new CityService(_logger, unitOfWork);
            BudgetService = new BudgetService(_logger, unitOfWork);
            CompanyService = new CompanyService(_logger, unitOfWork);
            CategoriesService = new CategoryService(_logger, unitOfWork);
            CustomerService = new CustomerService(_logger, unitOfWork);
            EmployeeAttendanceService = new EmployeeAttendanceService(_logger, unitOfWork);
            EmployeeService = new EmployeeService(_logger, unitOfWork);
            InvoicesService = new InvoicesService(_logger, unitOfWork);
            MaintenanceOperationService = new MaintenanceOperationService(_logger, unitOfWork);
            PayrollService = new PayrollService(_logger, unitOfWork);
            ProcurementProductsService = new ProcurementProductsService(_logger, unitOfWork);
            ProcurementsService = new ProcurementsService(_logger, unitOfWork);
            ProductsService = new ProductsService(_logger, unitOfWork);
            SalesProductsService = new SalesProductsService(_logger, unitOfWork);
            SupplierService = new SupplierService(_logger, unitOfWork);
            SaleService = new SalesService (_logger, unitOfWork);
            WorkshopService = new WorkshopService(_logger, unitOfWork);
            WorkshopEmployeeScheduleService = new WorkshopEmployeeScheduleService(_logger, unitOfWork);
        }
    }
}
