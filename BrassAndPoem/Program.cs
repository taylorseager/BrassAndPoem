using System.Xml.Linq;

List<Product> products = new List<Product>()
{
    new Product(name: "Trumpet", price: 50.75M, productTypeId: 1),
    new Product(name: "Falling Up by Shel Silverstein", price: 15.99M, productTypeId: 2),
    new Product(name: "The Final Flight by Unknown", price: 10.99M, productTypeId: 2),
    new Product(name: "French Horn", price: 45.98M, productTypeId: 1),
    new Product(name: "Tuba", price: 64.99M, productTypeId: 1),
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType(title: "Brass", id: 1),
    new ProductType(title: "Poem", id: 2),
};

string greeting = "Welcome to Melodies & Metaphors";
Console.WriteLine(greeting);

//implement your loop here
DisplayMenu();

void DisplayMenu()
{
    string choice = null;
    while (choice != "5")
    {
        Console.WriteLine(@"Choose an option:
                          1. Display All Products
                          2. Delete A Product
                          3. Add A New Product
                          4. Update A Product
                          5. Exit");

        choice = Console.ReadLine();
        if (choice == "5")
        {
            Console.WriteLine("Come back again soon!");
        }
        else if (choice == "1")
        {
            DisplayAllProducts();
        }
        else if (choice == "2")
        {
            DeleteProduct();
        }
        else if (choice == "3")
        {
            AddProduct();
        }
        else if (choice == "4")
        {
            UpdateProduct();
        }
    }
}

void DisplayProductTypes()
{
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i+1}. {productTypes[i].Title}");
    }
}

void DisplayAllProducts()
{
    Console.WriteLine("All products:");
    for (int i = 0; i < products.Count; i++)
    {
        string type = products[i].ProductTypeId == 1 ? "Brass" : "Poem";
        Console.WriteLine($"{i + 1}. {products[i].Name} costs {products[i].Price} and is in {type} category.");
    } 
}

void DeleteProduct()
{
    DisplayAllProducts();
    Console.WriteLine("Please enter product number to delete:");
    int chosenIndex;
    while (!int.TryParse(Console.ReadLine().Trim(), out chosenIndex)) ;

    if (chosenIndex >= 1 && chosenIndex <= products.Count)
    {
        int selectedIndex = chosenIndex - 1;
        var selectedProduct = products[selectedIndex];

        products.Remove(selectedProduct);
        Console.WriteLine($"{selectedProduct.Name} has been successfully deleted.");
    }
}

void AddProduct()
{
    Console.WriteLine("Enter the details for the new product:");
    Console.WriteLine("Name: ");
    string name = Console.ReadLine().Trim();

    Console.WriteLine("Asking Price: ");
    decimal price;
    while (!decimal.TryParse(Console.ReadLine().Trim(), out price));

    Console.WriteLine($"Please select a Product Id:");
    DisplayProductTypes();
    int productTypeId;
    while (!int.TryParse(Console.ReadLine().Trim(), out productTypeId));


    Product newProduct = new Product(name, price, productTypeId);
    products.Add(newProduct);

    Console.WriteLine($"The product {newProduct.Name} has been added!");
}

void UpdateProduct()
{
    DisplayAllProducts();
    Console.WriteLine("Please select a product to update:");
    int chosenIndex;
    while (!int.TryParse(Console.ReadLine().Trim(), out chosenIndex)) ;

    if (chosenIndex >= 1 && chosenIndex <= products.Count)
    {
        int selectedIndex = chosenIndex - 1;
        var selectedProduct = products[selectedIndex];

        Console.WriteLine($"Updating product: {selectedProduct.Name}");

        Console.WriteLine("Enter new product name (or press Enter to keep current):");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            selectedProduct.Name = newName;
        }

        Console.WriteLine("Enter new prodcut price (or press Enter to keep current):");
        decimal newPrice;
        if (decimal.TryParse(Console.ReadLine().Trim(), out newPrice))
        {
            selectedProduct.Price = newPrice;
        }

        Console.WriteLine("Enter new product type ID (or press Enter to keep current):");
        DisplayProductTypes();
        int newProductTypeId;

        if (int.TryParse(Console.ReadLine().Trim(), out newProductTypeId))
        {
            selectedProduct.ProductTypeId = newProductTypeId;
        }

    Console.WriteLine($"{selectedProduct.Name} updated successfully.");
    }
    else
    {
        Console.WriteLine("Invalid selection. Please choose a valid product number.");
    }
}

// don't move or change this!
public partial class Program { }