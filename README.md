# Bank Account Management System

## Description

This project implements a bank account management system for a credit union. The system allows the registration of account holders and management of bank accounts, including deposit, withdrawal, interest application, and earnings. The system supports two types of accounts: Checking Account and Savings Account.

## Features

- **Account Holder Registration**: Includes CPF, name, address, and profession.
- **Account Creation**: Support for Checking Account and Savings Account.
- **Bank Operations**:
  - Deposit
  - Withdrawal
  - Earnings application (for Savings Account)
  - Interest application (for Checking Account)
- **Interest Calculation**:
  - Interest applied to negative balance (Checking Account)
  - Earnings applied to the balance of the Savings Account

## Technologies Used

- **Language**: C#
- **Framework**: .NET Core
- **Database**: In-memory Database for development and testing
- **ORM**: Entity Framework
- **Libraries**: FluentValidation for validation
- **Extras**: Docker

## Project Structure

- **Application**: Contains application logic and services.
- **Domain**: Defines domain entities and enums.
- **Infrastructure**: Data access and repository implementations.
- **WebApi**: API implementation for system interaction.
