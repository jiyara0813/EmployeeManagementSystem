# Employee Management System

A simple **Employee Management System** built with **C# Windows Forms** for the client application and **ASP.NET Core Web API** for the backend. This project allows you to **view, add, edit, and delete employee records** through a user-friendly interface.

---

## Table of Contents

- [Features](#features)  
- [Technologies](#technologies)  
- [Getting Started](#getting-started)  
- [Installation](#installation)  
- [Database Setup](#database-setup)
- [Usage](#usage)  
- [Notes](#notes)    

---

## Features

- Add new employees with basic information.  
- View all employee records in a grid.  
- Edit existing employee information.  
- Delete employees from the database.  
- Connects to a RESTful API backend for data management.  

---

## Technologies

- **C#** (Windows Forms Application)  
- **.NET 8.0**  
- **ASP.NET Core Web API**  
- **JSON** for client-server communication  

---

## Getting Started

These instructions will help you get a copy of the project running on your local machine.

### Prerequisites

- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/) (for development)  
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  

---

## Installation

1. Clone the repository

- git clone https://github.com/YourUsername/EmployeeManagementSystem.git

2. Open the solution in Visual Studio

- Open EmployeeManagementSystem.sln which contains the Windows Forms client and the API project. Restore NuGet packages if needed.

---

## Database Setup

1. Open SQL Server Management Studio (SSMS)

2. Run the SQL script located at Database/database_setup.sql to create the database and Employees table.

3. Update the connection string in the API `appsettings.json` if necessary.

---

## Usage

You can configure Visual Studio to start both projects at the same time:

1. Right-click the solution in **Solution Explorer** → **Properties**.

2. In the **Common Properties** → **Startup Project** section:  
	- Select **Multiple startup projects**.  
	- Set **Action** to **Start** for both:  
		- `Employee_MS.API`  
		- `EmployeeListApplication`  

3. Click **Apply** and then **OK**.  

4. Press **F5** or click **Start Debugging**.  
	- The API will start first (default: `http://localhost:5000`).  
	- The Windows Forms app will launch and connect to the running API.
	- Use buttons and try the Application.

---

## Notes

- Always ensure the API starts before the Windows Forms app if you run them separately.
- The sample data is optional; you can add your own employees.


