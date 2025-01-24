namespace ERP.API.DataAccessLayer.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAddressRepository Address { get; }
        ICountryRepository Country  { get; }
        IDistrictRepository District {  get; }
        ICityRepository City   { get; }
        IBudgetRepository Budget { get; }
        ICompanyRepository Company { get; }
        ICategoryRepository Category { get; }
        ICustomerRepository Customer { get; }
        IEmployeeAttendanceRepository EmployeeAttendance { get; }
        IEmployeeRepository Employee { get; }
        IInvoicesRepository Invoices { get; }
        IMaintenanceOperationRepository MaintenanceOperation { get; }
        IPayrollRepository Payroll { get; }
        IProcurementProductsRepository ProcurementProducts { get; }
        IProcurementsRepository Procurements { get; }
        ISalesProductsRepository SalesProducts { get; }
        ISalesRepository sales { get; }
        ISupplierRepository Supplier { get; }
        IWorkshopEmployeeScheduleRepository WorkshopEmployeeSchedule { get; }
        IWorkshopRepository Workshop  { get; }
        IProductsRepository Products { get; }
    }
}
