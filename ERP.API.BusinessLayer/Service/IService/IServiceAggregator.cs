namespace ERP.API.BusinessLayer.Service.IService
{
    public interface IServiceAggregator
    {
        IAddressService AddressService { get; }
        ICountryService CountryService { get; }
        IDistrictService DistrictService { get; }
        ICityService CityService { get; }
        IBudgetService BudgetService { get; }
        ICompanyService CompanyService { get; }
        ICategoryService CategoriesService { get; }
        ICustomerService CustomerService { get; }
        IEmployeeAttendanceService EmployeeAttendanceService { get; }
        IEmployeeService EmployeeService { get; }
        IInvoicesService InvoicesService { get; }
        IMaintenanceOperationService MaintenanceOperationService { get; }
        IPayrollService PayrollService { get; }
        IProcurementProductsService ProcurementProductsService { get; }
        IProcurementsService ProcurementsService { get; }
        IProductsService ProductsService { get; }
        ISalesService SaleService { get; }
        ISalesProductsService SalesProductsService { get; }
        ISupplierService SupplierService { get; }
        IWorkshopService WorkshopService { get; }
        IWorkshopEmployeeScheduleService WorkshopEmployeeScheduleService { get; }
    }
}
