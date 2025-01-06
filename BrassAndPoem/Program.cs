
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

//put your greeting here

//implement your loop here


List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType
    {
        Title = "Poetry",
        Id = 1
    },
    new ProductType
    {
        Title = "Brass",
        Id = 2
    }
};

List<Product> products = new List<Product>()
{
    new Product 
    {   Name = "Trumpet", 
        Price = 150.99M, 
        ProductTypeId = 1 }, 
    new Product 
    { 
        Name = "Trombone", 
        Price = 246.99M, 
        ProductTypeId = 1 },
    new Product 
    {   Name = "Tuba", 
        Price = 1250.99M, 
        ProductTypeId = 1 },
    new Product 
    { 
        Name = "Ozymandias", 
        Price = 12350.99M, 
        ProductTypeId = 2 },
    new Product 
    { 
        Name = "Leaves of Grass", 
        Price = 15650.99M, 
        ProductTypeId = 2 }
};


Console.WriteLine("Welcome to Brass & Poem!!!");

string response = null;
while (response != "5")
{
    DisplayMenu();

    response = Console.ReadLine().Trim();

    if (response == "1")
    {
        DisplayAllProducts(products, productTypes);
    }
    else if (response == "2")
    {
        DeleteProduct(products, productTypes);
    }
    else if (response == "3")
    {
        AddProduct(products, productTypes);
    }
    else if (response == "4")
    {
        UpdateProduct(products, productTypes);
    }
    else if (response == "5")
    {
        Console.WriteLine("Goodbye!!!");
    }
}


void DisplayMenu()
{
    Console.WriteLine(@"
1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("All Products:");
    foreach(Product product in products)
    {
        ProductType productType = productTypes.Find(pt => pt.Id == product.ProductTypeId);
        Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Type: {productType.Title}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter product to delete: ");
    int productNumber = int.Parse(Console.ReadLine()) - 1;

    if (productNumber >= 0 && productNumber < products.Count)
    {
        Product productDelete = products[productNumber];
        products.Remove(productDelete);
        Console.WriteLine($"'{productDelete.Name}' deleted.");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter product name: ");
    string name = Console.ReadLine();

    Console.WriteLine("Enter product price: ");
    decimal price = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Enter product type ID: ");
    int productTypeId = int.Parse(Console.ReadLine());

    products.Add(new Product { Name = name, Price = price, ProductTypeId = productTypeId });
    Console.WriteLine($"Product '{name}' added.");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Entere product to update: ");
    int productNumber = int.Parse(Console.ReadLine()) - 1;

    if (productNumber >= 0 && productNumber < products.Count)
    {
        Product product = products[productNumber];

        Console.WriteLine($"Current Name: {product.Name}");
        Console.WriteLine("Enter new name: ");
        string newName = Console.ReadLine().Trim();
        if (!string.IsNullOrEmpty(newName)) product.Name = newName;

        Console.WriteLine($"Current Price: {product.Price}");
        Console.WriteLine("Enter new price: ");
        string newPrice = Console.ReadLine();
        if (!string.IsNullOrEmpty(newPrice)) product.Price = decimal.Parse(newPrice);

        Console.WriteLine($"Current Type: {productTypes.First(pt => pt.Id == product.ProductTypeId).Title}");
        Console.WriteLine("Enter new type ID: ");
        string newType = Console.ReadLine();
        if (!string.IsNullOrEmpty(newType)) product.ProductTypeId = int.Parse(newType);

        Console.WriteLine($"'{product.Name}' updated.");

    }
}

// don't move or change this!
public partial class Program { }
