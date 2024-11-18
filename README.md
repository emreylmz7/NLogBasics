# Order Management System with Logging

This project is a simple ASP.NET Core Web API for managing orders and products, with integrated logging using **NLog**. It includes endpoints for creating, updating, listing, and deleting both orders and products, while logging all actions for effective tracking and error management.

## Features

- **Product Management**: Add, update, list, and delete products.
- **Order Management**: Create, update, cancel, and list orders.
- **Logging with NLog**: Log each API request and response, track errors, and record system events to a file and console.

## Technology Stack

- **ASP.NET Core Web API**: Backend framework.
- **NLog**: For logging actions and errors.
- **C#**: Programming language.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/emreylmz7/NLogBasics.git
    ```

2. Navigate to the project directory:
    ```bash
    cd NLogBasics
    ```

3. Install dependencies (NLog):
    ```bash
    dotnet restore
    ```

4. Run the application:
    ```bash
    dotnet run
    ```

## Endpoints

### Product Endpoints

- **POST /api/product/add**: Add a new product.
- **PUT /api/product/update/{id}**: Update a product's name and price.
- **DELETE /api/product/delete/{id}**: Delete a product by ID.
- **GET /api/product/list**: List all products.

### Order Endpoints

- **POST /api/order/create**: Create a new order.
- **PUT /api/order/update/{id}**: Update an order's quantity and status.
- **DELETE /api/order/cancel/{id}**: Cancel an order by ID.
- **GET /api/order/list**: List all orders.

## Logging

The project uses **NLog** for logging API actions and errors. Logs are stored in a file (`logs/order-log.txt`) and are also displayed in the console. 

### Log Levels

- **Info**: Successful operations (e.g., order created, product updated).
- **Warn**: Warnings for missing resources (e.g., trying to update a non-existent product).
- **Error**: Errors encountered during operations.

## Project Structure

- **Controllers**: Contains API controllers for Products (`ProductController`) and Orders (`OrderController`).
- **Models**: Defines data models (`Product` and `Order`).
- **NLog Configuration**: Log settings are defined in the `nlog.config` file.

## Configuration

Customize log settings in the `nlog.config` file in the project root. You can change the log file path, console output, log levels, and more.

## License

This project is open-source and available under the [MIT License](LICENSE).
