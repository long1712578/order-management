# 🧾 Order Management - Clean Architecture (.NET 8)

A professional **Order Management API**, built with **ASP.NET Core 8** and **Entity Framework Core 8** using **Clean Architecture**, designed to demonstrate backend capability including database design, RESTful APIs, validation, layered architecture, and maintainable code.

---

## 🎯 Project Objective

This project is built as part of a backend developer assessment. It showcases the ability to:

- Design a normalized relational database
- Build RESTful APIs using .NET 8
- Understand backend workflows (CRUD, validation, relationships)
- Write clean, well-structured, and maintainable code
- Follow best practices with Clean Architecture
- Implement minimal unit testing (bonus)

---

## 🧱 Technology Stack

| Category          | Technology                        |
|-------------------|------------------------------------|
| Framework         | ASP.NET Core 8 Web API             |
| ORM               | Entity Framework Core 8 (Code-First)|
| Database          | SQL Server       |
| Documentation     | Swagger (Swashbuckle)              |
| Mapping           | AutoMapper                         |
| Validation        | DataAnnotations                    |
| Testing (bonus)   | xUnit                              |

---

## 🗂️ Clean Architecture Layers

This separation improves **testability**, **scalability**, and **maintainability**.

---

## 📦 Entities Overview

### Customer
- `CustomerId` (int, PK)
- `FullName` (string)
- `Email` (string)
- `PhoneNumber` (string)

### Product
- `ProductId` (int, PK)
- `Name` (string)
- `Price` (decimal)

### Order
- `OrderId` (int, PK)
- `CustomerId` (int, FK)
- `OrderDate` (datetime)
- `TotalAmount` (decimal)

### OrderItem
- `OrderItemId` (int, PK)
- `OrderId` (int, FK)
- `ProductId` (int, FK)
- `Quantity` (int)
- `UnitPrice` (decimal)

---

## 📡 API Endpoints

### 🔹 Customers
- `GET    /api/customers` → Get all customers
- `POST   /api/customers` → Add new customer
- `PUT    /api/customers/{id}` → Update customer
- `DELETE /api/customers/{id}` → Delete customer

### 🔹 Products
- `GET    /api/products` → Get all products

### 🔹 Orders
- `POST   /api/orders` → Create new order (with items)
- `GET    /api/orders` → List orders (filter by date or customer)
- `GET    /api/orders/{id}` → Get order detail

---

## ⚙️ How to Run the Project

### Step 1: Clone the Repository

```bash
git clone https://github.com/long1712578/order-management.git
cd order-management
```
### Step 2: Apply Database Migration

> Áp dụng cho cả người dùng Visual Studio và dòng lệnh `dotnet ef`.

#### 📌 Cấu hình chuỗi kết nối
Kiểm tra lại `appsettings.json` trong dự án `OrderManagement.Api` đã khai báo đúng connection string:

```json
"ConnectionStrings": {
  "Default": "Server=.;Database=OrderManagementDb;Trusted_Connection=True;Encrypt=False"
}
```

#### ✅ Cách 1: Dùng Package Manager Console (Visual Studio)

1. Mở **Tools > NuGet Package Manager > Package Manager Console**
2. Đảm bảo `Default project` là `OrderManagement.Infrastructure`
3. Chạy lần lượt:

```powershell
Add-Migration InitialCreate
Update-Database
```

#### ✅ Cách 2: Dùng .NET CLI

```bash
dotnet ef migrations add InitialCreate --project OrderManagement.Infrastructure --startup-project OrderManagement.Api
dotnet ef database update --project OrderManagement.Infrastructure --startup-project OrderManagement.Api
```

Sau khi thực hiện thành công, cơ sở dữ liệu `OrderManagementDb` sẽ được tạo trong SQL Server chứa đầy đủ bảng (Customers, Products, Orders, OrderItems).

### Step 3: Run the API

```bash
cd OrderManagement.Api
dotnet run
```
### Step 4: Testing
> Unit tests are written using **xUnit** and **Moq** to ensure business logic is correct and maintainable.
#### Using Visual Studio
1. Open the solution in Visual Studio.
2. Right-click the `OrderManagement.Tests` project.
3. Select __Run Tests__ or use the __Test Explorer__ window.

Test results will be displayed in the terminal or the Visual Studio Test Explorer.

---

Unit tests cover scenarios such as:
- Creating a customer
- Handling mapping errors
- Deleting a non-existent customer