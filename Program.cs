using InventoryManagementSystem;
//The entrypoint of the program 
Inventory inventory = new();
inventory.Load();

while (true)
{
    DisplayMenu();

    string choice = Console.ReadLine()!;

    //The user controlls the app via the following 6 choices
    switch (choice)
    {
        case "1":
            //Calling the suitable method 
            AddProduct();
            break;

        case "2":
            UpdateProduct();
            break;


        case "3":
            DeleteProduct();
            break;

        case "4":
            inventory.ViewProducts();

            break;

        case "5":
            inventory.GenerateReport();
            break;

        case "6":
            return;
    }

}

void DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--- Inventory Menu ---");
    Console.ResetColor();
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. Update Product");
    Console.WriteLine("3. Delete Product");
    Console.WriteLine("4. View Products");
    Console.WriteLine("5. Generate Report");
    Console.WriteLine("6. Exit");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Choose an option: ");
    Console.ResetColor();
}

void DisplayError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}

void DisplayAddMenu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--- Add Product ---");
    Console.ResetColor();
    Console.WriteLine("Please enter the product details:");
    Console.WriteLine("ID must be a positive integer, and Price must be a positive decimal number.");
    Console.WriteLine("Type 'exit' to return to the menu.");
}

void AddProduct()
{
    DisplayAddMenu();
    bool validInput = false;
    int id = 0;
    do
    {
        Console.Write("ID: ");
        string input = Console.ReadLine()!;
        if (input.ToLower() == "exit")
        {
            validInput = false;
            break;
        }

        if (int.TryParse(input, out id) && id > 0)
        {
            validInput = true;
            if (inventory.FindProductById(id, out _))
            {
                DisplayError($"Product with ID {id} already exists. Please enter a unique ID.");
                validInput = false;
                continue;
            }
            break;
        }
        else
        {
            DisplayError("Invalid ID. Please enter a positive integer.");
        }

    } while (true);

    if (!validInput)
    {
        Console.Clear();
        return;
    }

    string name = "";
    do
    {
        Console.Write("Name: ");
        string input = Console.ReadLine()!;

        if (input.Trim().ToLower() == "exit")
        {
            validInput = false;

            break;
        }

        if (string.IsNullOrWhiteSpace(input))
        {
            DisplayError("Name cannot be empty. Please enter a valid product name.");
            continue;
        }
        else
        {
            name = input.Trim();
            break;

        }

    } while (true);

    if (!validInput)
    {
        Console.Clear();
        return;
    }


    int qty = 0;
    do
    {
        Console.Write("Quantity: ");
        string input = Console.ReadLine()!;
        if (input.Trim().ToLower() == "exit")
        {
            validInput = false;
            break;
        }
        if (int.TryParse(input, out qty) && qty >= 0)
        {
            validInput = true;
            break;
        }
        else
        {
            DisplayError("Invalid Quantity. Please enter a non-negative integer.");
        }
    } while (true);

    if (!validInput)
    {
        Console.Clear();
        return;
    }


    decimal price = 0;
    do
    {
        Console.Write("Price: ");
        string input = Console.ReadLine()!;
        if (input.ToLower() == "exit")
        {
            validInput = false;
            break;
        }
        if (decimal.TryParse(input, out price) && price >= 0)
        {
            validInput = true;
            break;
        }
        else
        {
            DisplayError("Invalid Price. Please enter a positive decimal number.");
        }
    } while (true);

    if (!validInput)
    {
        Console.Clear();
        return;
    }



    Product product = new Product
    {
        Id = id,
        Name = name,
        Quantity = qty,
        Price = price
    };

    inventory.AddProduct(product);
    inventory.Save();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Product added successfuly");
    Console.ResetColor();
    Thread.Sleep(3000);
    Console.Clear();

}

void UpdateProduct()
{

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--- Update Product ---");
    Console.ResetColor();
    Console.WriteLine("Please enter the ID of the product you want to update.");
    Console.WriteLine("Press Enter to continue or type 'exit' to return to the menu.");
    int updateId = 0;
    Product sProduct = new Product();
    do
    {

        Console.Write("ID to update: ");
        string inputId = Console.ReadLine()!;
        bool validId = false;
        if (inputId.ToLower() == "exit")
        {
            Console.Clear();
            break;
        }
        if (!int.TryParse(inputId, out updateId) || updateId <= 0)
        {
            DisplayError("Invalid ID. Please enter a positive integer.");
            validId = false;
            continue;
        }
        if (!inventory.FindProductById(updateId, out sProduct))
        {
            DisplayError($"Product with ID {updateId} does not exist.");
            validId = false;
            continue;
        }
        if (!validId)
        {
            Console.Clear();
            break;
        }
    } while (true);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Updating Product ID: {updateId}");
    Console.ForegroundColor = ConsoleColor.Yellow;
    sProduct.DisplayProductInfo();
    Console.ResetColor();
    Console.WriteLine("Enter new details for the product.");
    Console.WriteLine("Type 'exit' to return to the menu.");
    Console.Write("New Name: ");

    string newName = Console.ReadLine()!;
    if (newName.Trim().ToLower() == "exit")
    {
        Console.Clear();
        return;
    }
    if (string.IsNullOrWhiteSpace(newName))
    {
        DisplayError("Name cannot be empty. Please enter a valid product name.");
        return;
    }

    int newQty = 0;
    Console.Write("New Quantity: ");
    if (newName.Trim().ToLower() == "exit")
    {
        Console.Clear();
        return;
    }
    if (!int.TryParse(Console.ReadLine(), out newQty) || newQty < 0)
    {
        DisplayError("Invalid Quantity. Please enter a non-negative integer.");
        return;
    }

    decimal newPrice = 0;
    Console.Write("New Price: ");
    if (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice < 0)
    {
        DisplayError("Invalid Price. Please enter a positive decimal number.");
        return;
    }

    inventory.UpdateProduct(updateId, newName, newQty, newPrice);
    inventory.Save();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Product Updated successfuly");
    Console.ResetColor();
    Thread.Sleep(3000);
    Console.Clear();

    return;

}

void DeleteProduct()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("--- Delete Product ---");
    Console.ResetColor();
    int deleteId = 0;
    do
    {
        bool validDeleteId = true;
        Console.WriteLine("Please enter the ID of the product you want to delete.");
        string inputDeleteId = Console.ReadLine()!;


        if (inputDeleteId.Trim().ToLower() == "exit")
        {
            Console.Clear();
            break;
        }
        if (!int.TryParse(inputDeleteId, out deleteId) || deleteId <= 0)
        {
            DisplayError("Invalid ID. Please enter a positive integer.");
            validDeleteId = false;
            continue;
        }
        if (!inventory.FindProductById(deleteId, out _))
        {
            DisplayError($"Product with ID {deleteId} does not exist.");
            validDeleteId = false;
            continue;
        }
        if (!validDeleteId)
        {
            Console.Clear();
            break;
        }


        inventory.DeleteProduct(deleteId);
        inventory.Save();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Product with ID {deleteId} has been deleted.");
        Console.ResetColor();
        Thread.Sleep(3000);
        Console.Clear();
        return;
    } while (true);
}