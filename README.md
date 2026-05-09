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

The purpose of the system is to manage and monitor ICT assets used within the SDJDP Document Centre through both a Desktop Application and a Web Application connected to the same SQL Server database.

The system allows users to:

- Add new assets
- Update asset information
- Delete asset records
- Search for assets
- View all assets
- Store and retrieve data from SQL Server
- Access the system through a login interface

---

# Technologies Used

## Desktop Application
- C#
- Windows Forms
- Visual Studio 2022

## Web Application
- ASP.NET Core Razor Pages
- HTML
- CSS

## Database
- SQL Server
- SQL Server Management Studio (SSMS)

## Version Control
- GitHub

---

# System Features

## Desktop Application Features

- Login Form
- MenuStrip
- StatusStrip
- NotifyIcon
- DatePicker
- GroupBox Controls
- CRUD Operations
- DataGridView Integration
- Search Functionality
- SQL Server Database Connectivity
- User-Friendly Interface

---

## Web Application Features

- Login Page
- Asset Management Page
- About Page
- Contact Page
- CRUD Operations
- SQL Server Integration
- Navigation Links
- Modern User Interface

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
5. Login using the system login form.
6. Perform CRUD operations.

---

# How to Run the Web Application

1. Open the web project in Visual Studio 2022.
2. Ensure SQL Server is running.
3. Execute the `database.sql` script if needed.
4. Run the ASP.NET Core Razor Pages project.
5. The login page will open first.
6. Click Login to access the Asset Management Portal.

---

# GitHub Repository

Repository Link:

```text
https://github.com/Dain05/SDJDP-Asset-Management-System
```

---

# Conclusion

The SDJDP Asset Management System successfully demonstrates the use of Enterprise Application Development concepts using Desktop and Web technologies integrated with SQL Server.

The project provides a practical solution for managing ICT assets while demonstrating CRUD functionality, database connectivity, modern interface design, and enterprise-level application structure.
