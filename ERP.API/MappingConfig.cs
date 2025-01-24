namespace ERP.API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //FinancialManagementSystem
            CreateMap<CreateBudgetDTO, Budget>().ReverseMap();
            CreateMap<UpdateBudgetDTO, Budget>().ReverseMap();

            CreateMap<CreateCompanyDTO, Company>().ReverseMap();
            CreateMap<UpdateCompanyDTO, Company>().ReverseMap();
            //HRManagementSystem
            CreateMap<CreateCustomerDTO, Customer>().ReverseMap();
            CreateMap<UpdateCustomerDTO, Customer>().ReverseMap();
            CreateMap<CreateEmployeeAttendanceDTO, EmployeeAttendance>().ReverseMap();
            CreateMap<UpdateEmployeeAttendanceDTO, EmployeeAttendance>().ReverseMap();
            CreateMap<CreateEmployeeDTO, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeDTO, Employee>().ReverseMap();
            CreateMap<CreatePayrollDTO, Payroll>().ReverseMap();
            CreateMap<UpdatePayrollDTO, Payroll>().ReverseMap();
            CreateMap<CreateSupplierDTO, Supplier>().ReverseMap();
            CreateMap<UpdateSupplierDTO, Supplier>().ReverseMap();
            //InvoiceManagementSystem
            CreateMap<CreateInvoicesDTO, Invoice>().ReverseMap();
            CreateMap<UpdateInvoicesDTO, Invoice>().ReverseMap();
            //MaintenanceManagementSystem
            CreateMap<CreateMaintenanceOperationDTO, MaintenanceOperation>().ReverseMap();
            CreateMap<UpdateMaintenanceOperationDTO, MaintenanceOperation>().ReverseMap();
            //ProcurementManagementSystem
            CreateMap<CreateProcurementsDTO, Procurement>().ReverseMap();
            CreateMap<UpdateProcurementsDTO, Procurement>().ReverseMap();
            CreateMap<CreateProcurementProductsDTO, ProcurementProduct>().ReverseMap();
            CreateMap<UpdateProcurementProductsDTO, ProcurementProduct>().ReverseMap();
            //ProductManagementSystem
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
            CreateMap<CreateProductsDTO, Product>().ReverseMap();
            CreateMap<UpdateProductsDTO, Product>().ReverseMap();
            //SalesManagementSystem
            CreateMap<CreateSalesDTO, Sale>().ReverseMap();
            CreateMap<UpdateSalesDTO, Sale>().ReverseMap();
            CreateMap<CreateSalesProductsDTO, SalesProduct>().ReverseMap();
            CreateMap<UpdateSalesProductsDTO, SalesProduct>().ReverseMap();
            //WorkshopManagementSystem
            CreateMap<CreateWorkshopDTO, Workshop>().ReverseMap();
            CreateMap<UpdateWorkshopDTO, Workshop>().ReverseMap();
            CreateMap<CreateWorkshopEmployeeScheduleDTO, WorkshopEmployeeSchedule>().ReverseMap();
            CreateMap<UpdateWorkshopEmployeeScheduleDTO, WorkshopEmployeeSchedule>().ReverseMap();
        }
    }
}
