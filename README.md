# SDJDP Asset Management System

## Course Information

| Item | Details |
|------|---------|
| Course | CS244 – Enterprise Application Development |
| Lecturer | Trevor Williams |
| Project Type | Group Assignment |
| Project Title | SDJDP Asset Management System |
| Submission Date | May 2026 |

---

## Group Members

| Name | Student ID |
|------|-------------|
| Dain Thorpe | 2301011605 |
| Joan Johnson-Brown | 2401010520 |
| Shanique Wisdom | 2401010649 |
| Pasha Pinnock | 2401011323 |
| Dante Graham | 2401010192 |

---

# Project Overview

The SDJDP Asset Management System is a database-driven enterprise application developed using C#, Windows Forms, ASP.NET Core Razor Pages, and SQL Server.

The system was designed to assist the SDJDP Document Centre with the management and monitoring of ICT assets through both a Desktop Application and a Web-Based Portal connected to the same SQL Server database.

The project demonstrates enterprise application development concepts including authentication, CRUD operations, database integration, user interface design, and multi-platform access.

---

# System Objectives

The system allows users to:

- Add new assets
- Update existing asset information
- Delete asset records
- Search for assets
- View all asset records
- Store and retrieve information from SQL Server
- Access the system through a login interface
- Manage assets through both Desktop and Web platforms

---

# Technologies Used

## Desktop Application
- C#
- Windows Forms
- .NET
- Visual Studio 2022

## Web Application
- ASP.NET Core Razor Pages
- HTML
- CSS
- Bootstrap

## Database
- SQL Server
- SQL Server Management Studio (SSMS)

## Version Control
- GitHub

---

# Desktop Application Features

- Login Authentication
- MDI Parent Form
- MenuStrip Integration
- StatusStrip Integration
- NotifyIcon Component
- DateTimePicker Component
- GroupBox Controls
- CRUD Operations
- Search Functionality
- SQL Server Connectivity
- DataGridView Integration
- User-Friendly Interface
- Logged-In User Display

---

# Web Application Features

- Login Page Authentication
- Asset Management Portal
- About Page
- Contact Page
- CRUD Operations
- Search Functionality
- SQL Server Integration
- Navigation System
- Responsive User Interface

---

# Database Information

## Database Name

```text
SDJDPAssetDB
```

## Table Name

```text
Assets
```

---

# Assets Table Structure

| Field Name | Data Type |
|------------|------------|
| AssetID | VARCHAR(20) |
| AssetType | VARCHAR(50) |
| SerialNumber | VARCHAR(50) |
| Department | VARCHAR(50) |
| Status | VARCHAR(30) |

---

# Sample Records

| AssetID | AssetType | SerialNumber | Department | Status |
|----------|------------|---------------|-------------|---------|
| A100 | Laptop | SN100 | ICT | Available |
| A101 | Printer | SN200 | Administration | In Use |
| A102 | Desktop PC | SN300 | Finance | Damaged |
| A200 | Projector | SN500 | Training | Available |

---

# SQL Script

```sql
CREATE DATABASE SDJDPAssetDB;
GO

USE SDJDPAssetDB;
GO

CREATE TABLE Assets
(
    AssetID VARCHAR(20) PRIMARY KEY,
    AssetType VARCHAR(50) NOT NULL,
    SerialNumber VARCHAR(50) NOT NULL,
    Department VARCHAR(50) NOT NULL,
    Status VARCHAR(30) NOT NULL
);
GO

INSERT INTO Assets VALUES
('A100', 'Laptop', 'SN100', 'ICT', 'Available'),
('A101', 'Printer', 'SN200', 'Administration', 'In Use'),
('A102', 'Desktop PC', 'SN300', 'Finance', 'Damaged'),
('A200', 'Projector', 'SN500', 'Training', 'Available');
GO
```

---

# How to Run the Desktop Application

1. Open the solution in Visual Studio 2022.
2. Open SQL Server Management Studio.
3. Execute the `database.sql` script.
4. Run the Windows Forms project.
5. Login using:

```text
Username: admin
Password: admin123
```

6. Access the SDJDP Asset Management System.
7. Perform CRUD operations.

---

# How to Run the Web Application

1. Open the ASP.NET Core project in Visual Studio 2022.
2. Ensure SQL Server is running.
3. Execute the `database.sql` script if required.
4. Run the ASP.NET Core Razor Pages project.
5. The login page will open first.
6. Login using:

```text
Username: admin
Password: admin123
```

7. Access the Asset Management Portal.

---

# GitHub Repository

Repository Link:

```text
https://github.com/Dain05/SDJDP-Asset-Management-System
```

---

# Conclusion

The SDJDP Asset Management System successfully demonstrates Enterprise Application Development concepts using Desktop and Web technologies integrated with SQL Server.

The project provides a practical solution for managing ICT assets while demonstrating authentication, CRUD functionality, database connectivity, responsive interface design, and enterprise-level application structure.
