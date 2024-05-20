# Gym API Management written in C# with .net core

## Software Structure

```
├── PUMP.api
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── Controllers
│   │   ├── AccessesController.cs
│   │   ├── CategoryController.cs
│   │   ├── DetailMembershipsController.cs
│   │   ├── EmployeesController.cs
│   │   ├── MembersController.cs
│   │   ├── MembershipsController.cs
│   │   ├── ProductsController.cs
│   │   └── ProductsPaymentsController.cs
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   ├── PUMP.api.csproj
│   └── PUMP.api.http
├── PUMP.core
│   ├── BL
│   │   ├── Interfaces
│   │   │   ├── IAccesses.cs
│   │   │   ├── ICategory.cs
│   │   │   ├── IDetailMemberships.cs
│   │   │   ├── IEmployees.cs
│   │   │   ├── IMembers.cs
│   │   │   ├── IMemberships.cs
│   │   │   ├── IProducts.cs
│   │   │   └── IProductsPayments.cs
│   │   └── Services
│   │       ├── AccessesServices.cs
│   │       ├── CategoryServices.cs
│   │       ├── DetailMembershipsServices.cs
│   │       ├── EmployeesServices.cs
│   │       ├── MembershipsServices.cs
│   │       ├── MembersServices.cs
│   │       ├── ProductsPaymentsServices.cs
│   │       └── ProductsServices.cs
│   └── PUMP.core.csproj
│   ├── PUMP.data.csproj
│   └── SQLServer
│       └── InitDb.cs
├── PUMP.helpers
│   ├── PUMP.helpers.csproj
│   └── Settings.cs
└── PUMP.models
    ├── Accesses.cs
    ├── Category.cs
    ├── DetailMemberships.cs
    ├── Employees.cs
    ├── Members.cs
    ├── Memberships.cs
    ├── Products.cs
    ├── ProductsPayments.cs
    └── PUMP.models.csproj

```
