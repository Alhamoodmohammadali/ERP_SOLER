# ERP Backend System

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![ASP.NET Core](https://img.shields.io/badge/framework-ASP.NET%20Core%209-blue)
![SQL Server](https://img.shields.io/badge/database-SQL%20Server-orange)

## 📖 Overview
This is a **multi-tenant ERP backend system** designed to optimize the operations of small and medium-sized businesses. Built with **ASP.NET Core 9**, the application manages HR, finance, invoicing, inventory, and more while ensuring secure multi-tenancy with robust data isolation.

The system is modular and highly scalable, utilizing **SOLID principles**, **Repository Pattern**, and **ADO.NET** for peak performance. A strong focus is placed on data integrity, security, and speed, leveraging **Stored Procedures** and **Indexed Views** in **SQL Server**.

---

## 🚀 Features
- **Multi-Tenant Architecture**: Secure data isolation for multiple companies within the same system.
- **Role-Based Access Control**:
  - **Super Admin**: Manages user and company creation, but cannot view company-specific data.
  - **Company Admin**: Manages company-level operations and assigns roles to users.
  - **Regular Users**: Limited access based on role permissions.
- **Modules**:
  - Human Resource Management (HRM).
  - Financial Accounting.
  - Invoicing and Sales.
  - Inventory and Product Management.
  - Maintenance and Workshop Management.
  - Procurement Operations.
- **Performance Optimization**:
  - **ADO.NET** for direct and efficient database communication.
  - Use of **Stored Procedures** for secure and fast data operations.
  - **Indexes** and **Views** to enhance query performance.
- **Security**:
  - Authentication with **Identity Framework**.
  - Strong isolation between tenant data.

---

## 📂 Project Structure

The solution is divided into multiple libraries for modularity and maintainability:

### **Main API Project**
- **ERP.API**: The entry point, hosting all the controllers and handling API requests.

### **Business Layer**
Contains the core business logic, organized by functional modules:
- **ServiceAddress**: Manages addresses, cities, districts, and countries.
  - `AddressService`, `CityService`, `CountryService`, `DistrictService`.
- **ServiceAuth**: Handles authentication and user roles.
- **ServiceFinancial**: Financial accounting and transaction management.
- **ServiceHRM**: Human resource management (employee data, payroll, attendance).
- **ServiceInventory**: Inventory tracking and stock management.
- **ServiceInvoice**: Sales invoicing and billing.
- **ServiceMaintenance**: Maintenance requests and management.
- **ServiceProcurement**: Procurement and supplier management.
- **ServiceProductManagement**: Product lifecycle and categorization.
- **ServiceSales**: Sales operations.
- **ServiceWorkshop**: Workshop and task management.

### **Data Access Layer**
- **ERP.API.DataAccessLayer**:
  - Contains **Repositories** to abstract database operations.
  - Uses **ADO.NET** for optimized and secure data access.
  - Implements **Stored Procedures** for all critical database interactions.

### **Utility Library**
- **ERP.API.Utility**:
  - Contains shared utilities, such as logging, error handling, and common helpers.

---

## ⚙️ Database Design

### **Database Overview**
The system uses **SQL Server** as the primary database, designed for high performance and scalability. Key features include:
- **Stored Procedures** for CRUD operations, ensuring data security and reducing the risk of SQL injection.
- **Indexed Views** to optimize performance for complex queries.
- Separate schemas for tenant data to maintain isolation.

### **Core Tables**:
1. **Tenants**: Stores company-specific metadata.
   - `TenantID`, `CompanyName`, `CreatedAt`, `SubscriptionStatus`.
2. **Users**: Manages users and their roles.
   - `UserID`, `Email`, `PasswordHash`, `Role`, `TenantID`.
3. **HRM**: Handles employee data.
   - `EmployeeID`, `FirstName`, `LastName`, `HireDate`, `Position`, `TenantID`.
4. **Finance**: Tracks financial transactions and accounts.
   - `TransactionID`, `Amount`, `Description`, `TransactionDate`, `TenantID`.
5. **Inventory**: Tracks inventory and stock.
   - `ProductID`, `ProductName`, `Stock`, `ReorderLevel`, `TenantID`.
6. **Invoices**: Tracks sales and billing.
   - `InvoiceID`, `CustomerName`, `TotalAmount`, `CreatedAt`, `TenantID`.

---

## 📄 API Endpoints

### **Authentication**
- **POST** `/api/auth/login`: User login.
- **POST** `/api/auth/register`: Register a new user.

### **Company Management**
- **POST** `/api/companies`: Create a new company (Super Admin only).
- **GET** `/api/companies`: Get a list of all companies.

### **Address Management**
- **GET** `/api/address/countries`: Get all countries.
- **GET** `/api/address/cities/{countryId}`: Get cities by country.

### **HRM**
- **GET** `/api/hr/employees`: Get all employees for a tenant.
- **POST** `/api/hr/employees`: Add a new employee.

### **Inventory**
- **GET** `/api/inventory/products`: Get a list of all products.
- **POST** `/api/inventory/products`: Add a new product.

---

## 💡 Key Design Highlights
- **SOLID Principles**: The application follows SOLID principles for maintainability and scalability.
- **Repository Pattern**: Abstracts database interactions for cleaner and more testable code.
- **Unit Testing**: Comprehensive tests for business logic and database operations.

---

## 📸 Screenshots
- **Architecture Diagram**: A high-level overview of the system.
![Architecture Diagram](docs/architecture-diagram.png)

- **API Usage Example**: Sample requests and responses.
![API Example](docs/api-example.png)

---

## 📋 Installation Guide

### Prerequisites:
- **.NET Core 9 SDK**.
- **SQL Server**.

### Steps:
1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/erp-backend.git
    cd erp-backend
    ```
2. Configure the database connection in `appsettings.json`.
3. Run SQL scripts from `sql-scripts/` to set up the database.
4. Build and run the project:
    ```bash
    dotnet restore
    dotnet build
    dotnet run
    ```

---

## 🛠 Future Enhancements
- Add a **reporting module** for generating financial and operational reports.
- Implement **caching** for frequently accessed data.
- Extend API documentation using **Swagger** for easier integration.

---

## 👥 Contributors
- **Your Name**: [GitHub Profile](https://github.com/your-username)

---

## 📜 License
This project is licensed under the [MIT License](LICENSE).
