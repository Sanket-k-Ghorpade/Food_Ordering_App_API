### Food Ordering App API

This repository contains the source code for a complete and robust RESTful API for a food ordering system, built with **ASP.NET Core**. The project is designed using a clean, layered architecture to ensure separation of concerns and maintainability.

---
### ## Key Features

* **Role-Based Access Control**: Differentiates between `ADMIN` and `MEMBER` roles for secure endpoint access.
* **Full CRUD Operations**: Admins can manage Menus, Menu Items, Delivery Partners, and Discount Rules.
* **Complex Order Placement**: Users can place orders with multiple items, and the system handles all backend logic.
* **Dynamic Discount System**: Automatically applies the best available discount based on the order total and defined rules.
* **Automatic Delivery Partner Assignment**: Assigns a random, available delivery partner to new orders.
* **Secure User Management**: Includes endpoints for user registration and password management.

---
### ## Tech Stack & Architecture

This API is built using modern .NET practices and a clean, decoupled architecture.

* **Framework**: ASP.NET Core
* **Data Access**: Entity Framework Core
* **Architecture**:
    * Layered Architecture (Controllers, Services, Repositories)
    * Repository & Unit of Work Patterns
    * Dependency Injection
* **Mapping**: AutoMapper for DTO-entity transformations
* **API Design**: RESTful, using Data Transfer Objects (DTOs) to define a clear API contract.
