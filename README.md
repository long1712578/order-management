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
