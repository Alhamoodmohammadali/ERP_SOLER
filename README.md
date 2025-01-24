# ERP Backend System (ASP.NET Core 9)

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![Framework](https://img.shields.io/badge/framework-ASP.NET%20Core%209-blue)
![Database](https://img.shields.io/badge/database-SQL%20Server-orange)

## 📖 Overview
This is a **highly scalable multi-tenant ERP backend system** built with **ASP.NET Core 9**, designed to optimize the management of small and medium-sized businesses. The system handles operations related to HR, finance, invoicing, inventory, and more, with a robust **data isolation mechanism** ensuring that each tenant has secure access to its own resources.

This repository showcases key excerpts of the project, but it contains **far more functionality and implementation details** beyond what's highlighted here.

---

## 🚀 Features at a Glance
- **Multi-Tenant Architecture**:
  - Complete data isolation between companies.
  - Tenant-based role management with granular permissions.
  
- **Role-Based Access Control**:
  - **Super Admin**: Can create companies and users but has no access to company data.
  - **Company Admin**: Full control over company operations and user management.
  - **Standard Users**: Access restricted by roles and permissions.

- **Core Modules**:
  - Human Resource Management (**HRM**).
  - Financial Management.
  - Inventory and Stock Tracking.
  - Sales and Invoicing.
  - Maintenance Requests.
  - Product and Procurement Management.
  - Workshop Operations.

- **Optimized for Performance**:
  - Direct database access with **ADO.NET** for critical operations.
  - **Stored Procedures**, **Indexes**, and **Views** in SQL Server.
  - Modular services for each business function to ensure scalability.

- **Advanced Security**:
  - Authentication via **Identity Framework**.
  - SQL Injection prevention through parameterized queries and stored procedures.

---

## 📂 Solution Structure

The project is organized into multiple libraries to ensure maintainability and clear separation of concerns:

### **Main Project: ERP.API**
The main entry point hosting API endpoints with controllers for all modules.

### **Business Layer: ERP.API.BusinessLayer**
- Contains all service logic for the modules:
  - `ServiceAddress` (Addresses, Cities, Districts, Countries).
  - `ServiceAuth` (Authentication and Roles).
  - `ServiceFinancial` (Financial operations).
  - `ServiceHRM` (Human resources).
  - `ServiceInventory` (Inventory management).
  - `ServiceInvoice` (Invoicing and billing).
  - `ServiceProcurement` (Procurement processes).
  - `ServiceProductManagement` (Products and categories).
  - `ServiceSales` (Sales operations).
  - `ServiceWorkshop` (Workshops and maintenance).

### **Data Access Layer: ERP.API.DataAccessLayer**
- Implements **Repository Pattern** to abstract database operations.
- Uses **ADO.NET** for efficient and secure database access.
- All critical operations rely on **Stored Procedures**.

### **Utility Layer: ERP.API.Utility**
- Shared utilities and helpers, such as:
  - Logging.
  - Exception handling.
  - Configuration utilities.

---

## 📄 Database Design

### **Key Highlights**:
- Designed for **multi-tenant data isolation**.
- Focus on performance and scalability using:
  - **Stored Procedures** for all CRUD operations.
  - **Indexed Views** for frequently queried data.

### **Core Tables**:
1. **Tenants**: Manages tenant-specific metadata.
2. **Users**: Handles user data and roles.
3. **HRM**: Stores employee data, attendance, and payroll information.
4. **Finance**: Tracks financial transactions and account details.
5. **Inventory**: Manages stock levels and product information.
6. **Invoices**: Tracks sales and billing.
7. **Procurement**: Stores supplier and procurement data.

### **Scalability and Security**:
- Tenant ID is embedded in every query to isolate data.
- Parameterized queries prevent SQL Injection.

---

## 🛠 Installation and Setup

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
3. Run the SQL scripts in `sql-scripts/` to set up the database.
4. Build and run the project:
    ```bash
    dotnet restore
    dotnet build
    dotnet run
    ```

---

## 📋 API Endpoints (Examples)
### **Authentication**
- **POST** `/api/auth/login`: User login with email and password.
- **POST** `/api/auth/register`: Register a new user.

### **Address Management**
- **GET** `/api/address/countries`: List all countries.
- **GET** `/api/address/cities/{countryId}`: Get cities by country.

### **HRM**
- **GET** `/api/hr/employees`: Retrieve employees for a tenant.
- **POST** `/api/hr/employees`: Add a new employee.

### **Inventory**
- **GET** `/api/inventory/products`: List all products.
- **POST** `/api/inventory/products`: Add a new product.

---

## 📸 Screenshots and Documentation
This repository includes **key excerpts of the full implementation**. Additional features, diagrams, and screenshots (e.g., architecture diagrams, database schemas, etc.) are available upon request.

---

## 🎯 Why This Project Stands Out

- **Enterprise-Level Architecture**:
  - Modular design ensures easy maintenance and scalability.
- **Performance Focus**:
  - Leveraged ADO.NET, Stored Procedures, and Indexes to minimize latency.
- **Secure Multi-Tenancy**:
  - Isolated data and role-based permissions ensure robust security.

---

## 🌟 What's Next
Future improvements and extensions could include:
- Advanced reporting and analytics module.
- Real-time notifications and alerting.
- Enhanced caching for frequently accessed data.

---

## 👥 Contributors
- **[Alhamood ali mohammad]( https://github.com/Alhamoodmohammadali/ERP_SOLER)**

---

## 📜 License
This project is licensed under the [MIT License](LICENSE).
