﻿global using Microsoft.Extensions.Logging;
global using ERP.API.DataAccessLayer.Models.HRM;
global using ERP.API.BusinessLayer.Service.IService;
global using ERP.API.DataAccessLayer.Models.Financial;
global using ERP.API.DataAccessLayer.Repository.IRepository;
global using ERP.API.BusinessLayer.Service.IService.IServiceHRM;
global using ERP.API.BusinessLayer.Service.IService.IServiceInventory;
global using ERP.API.BusinessLayer.Service.IService.IServiceFinancial;
global using ERP.API.DataAccessLayer.Models.Inventory;
global using ERP.API.BusinessLayer.Service.IService.IServiceInvoice;
global using ERP.API.DataAccessLayer.Models.Invoice;
global using ERP.API.BusinessLayer.Service.IService.IServiceMaintenance;
global using ERP.API.DataAccessLayer.Models.Maintenance;
global using ERP.API.BusinessLayer.Service.IService.IServiceProcurement;
global using ERP.API.DataAccessLayer.Models.Procurement;
global using ERP.API.BusinessLayer.Service.IService.IServiceProductManagement;
global using ERP.API.DataAccessLayer.Models.Products.Product;
global using ERP.API.DataAccessLayer.Models.Product;
global using ERP.API.BusinessLayer.Service.IService.IServiceSales;
global using ERP.API.DataAccessLayer.Models.Sales;
global using ERP.API.DataAccessLayer.Models.Workshop;
global using ERP.API.DataAccessLayer.Models.Address;
global using ERP.API.BusinessLayer.Service.IService.IServiceAddress;
global using ERP.API.BusinessLayer.Service.ServiceFinancial;
global using ERP.API.BusinessLayer.Service.ServiceHRM;
global using ERP.API.BusinessLayer.Service.ServiceInvoice;
global using ERP.API.BusinessLayer.Service.ServiceMaintenance;
global using ERP.API.BusinessLayer.Service.ServiceProcurement;
global using ERP.API.BusinessLayer.Service.ServiceProductManagement;
global using ERP.API.BusinessLayer.Service.ServiceSales;
global using ERP.API.BusinessLayer.Service.ServiceWorkshop;
global using ERP.API.BusinessLayer.Service.ServiceAddress;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using ERP.API.BusinessLayer.Service.IService.IServiceAuth;
global using ERP.API.DataAccessLayer.Models.Auth;
