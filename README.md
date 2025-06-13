# Inventory Management System

A simple console-based Inventory Management System built with C# and .NET 8. This application allows users to manage products in an inventory, including adding, updating, deleting, viewing, and generating reports for products.

## Features

- Add new products with unique IDs
- Update existing product details
- Delete products from the inventory
- View all products in a tabular format
- Generate inventory reports
- Data persistence between sessions
- User-friendly console interface with input validation

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Setup
1. Clone the repository or download the source code.
2. Open the project in your preferred IDE (e.g., Visual Studio, VS Code).
3. Restore dependencies (if any):
   ```sh
   dotnet restore
   ```
4. Build the project:
   ```sh
   dotnet build
   ```
5. Run the application:
   ```sh
   dotnet run --project InventoryManagementSystem
   ```

## Usage

When you run the application, you will see a menu with the following options:

1. **Add Product**: Enter product details (ID, Name, Quantity, Price) to add a new product.
2. **Update Product**: Update the name, quantity, or price of an existing product by ID.
3. **Delete Product**: Remove a product from the inventory by ID.
4. **View Products**: Display all products in the inventory.
5. **Generate Report**: Generate a summary report of the inventory.
6. **Exit**: Close the application.

All inputs are validated, and helpful error messages are displayed for invalid entries.

## Project Structure

- `Program.cs`: Main entry point and user interface logic.
- `Inventory.cs`: Inventory management logic (add, update, delete, find, save, load, report).
- `Product.cs`: Product data model and display logic.

## Data Persistence

The application saves inventory data between sessions. The data file is created and managed automatically.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License.

## Author

- Khattab Alshami
