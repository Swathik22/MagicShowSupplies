// See https://aka.ms/new-console-template for more information

List<Product> products=new List<Product>()
{
    new Product()
    {
        Name="Magic Wand",
        Price=25.99M,
        Sold=false,
        ProductTypeId=1,
        DateStocked=new DateTime(2024,1,2)
    },
    new Product()
    {
        Name="Spellbook",
        Price=39.99M,
        Sold=false,
        ProductTypeId=2,
        DateStocked=new DateTime(2023,12,20)
    },
    new Product()
    {
        Name="Crystal Ball",
        Price=49.99M,
        Sold=false,
        ProductTypeId=3,
        DateStocked=new DateTime(2024,3,5)
    },
    new Product()
    {
        Name="Wizard Hat",
        Price=19.99M,
        Sold=true,
        ProductTypeId=2,
        DateStocked=new DateTime(2023,11,22)
    },
    new Product()
    {
        Name="Magic Cloak",
        Price=59.99M,
        Sold=true,
        ProductTypeId=4,
        DateStocked=new DateTime(2024,2,15)
    }  
};

List<ProductCategory> productCategories=new List<ProductCategory>()
{
    new ProductCategory()
    {
        Id=1,
        Category="Apparel"
    },
    new ProductCategory()
    {
        Id=2,
        Category="Potions"
    },
    new ProductCategory()
    {
        Id=3,
        Category="Enchanted Objects"
    },
    new ProductCategory()
    {
        Id=4,
        Category="Wands"
    }
};
Console.WriteLine("Enchanted Emporium: Your One-Stop Shop for Magical Show Supplies!");
string choice=null;
while(choice!="1")
{
    Console.WriteLine(@"Choose an Option for your Shopping
                        1. Exit
                        2. View All Products
                        3. Add a Product to Inventory
                        4. Delete a Product
                        5. Update a Product
                        6. View All Available Products");

    choice=Console.ReadLine();

    switch(choice)
    {
        case "2":
            ViewAllProducts();
            break;

        case "3":
            AddProduct();
            break;

        case "4":
            DeleteProduct();
            break;

        case "5":
            UpdateProduct();
            break;

        case "6":
            ViewAllAvailableProducts();
            break;

        default:
            Console.WriteLine("Namaskaram");
            break;
    }

}

void ViewAllProducts()
{
    Console.WriteLine("The Magic show Products :");
    for(int i=0;i<products.Count;i++)
    {
        Console.WriteLine($"{i+1}. The {products[i].Name} price is {products[i].Price} dollar and {(products[i].Sold?"is Sold":"is available")} from {products[i].DaysOnShelf} days.");
    }
}

void AddProduct()
{
    Product newProduct=new Product();
    Console.WriteLine("You can add a product to the inventory");
    Console.Write("ProductName : ");
    newProduct.Name=Console.ReadLine();

    Console.Write("Price : ");
    newProduct.Price=Convert.ToDecimal(Console.ReadLine());

    newProduct.Sold=false;

    Console.Write("Select the Product Type:");
    
    // foreach(ProductCategory type in productCategories)
    // {
    //     Console.WriteLine($"{type.Id}. {type.Category}");
    // }
    
    productCategories.Select(type => $"{type.Id}. {type.Category}")
                 .ToList()
                 .ForEach(Console.WriteLine);
                 
    newProduct.ProductTypeId=int.Parse(Console.ReadLine());

    products.Add(newProduct);
    Console.WriteLine("Product added successfully.");

    ViewAllProducts();

}

void DeleteProduct()
{
    Console.WriteLine("Select a Product which you want to delete");
    ViewAllProducts();
    
    int i=int.Parse(Console.ReadLine());

    if(i>products.Count)
    {
        products.RemoveAt(i-1);
    }

    Console.WriteLine("Product deleted successfully.");
    
    ViewAllProducts();
}

void UpdateProduct()
{
    ViewAllProducts();
    Console.WriteLine("Enter the product you want to update");

    int prod=int.Parse(Console.ReadLine());

    Console.WriteLine("Change the price : ");
    products[prod-1].Price=Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine("Updated Successfully: ");
    Console.WriteLine($"{prod}. The {products[prod-1].Name} price is {products[prod-1].Price} dollar and {(products[prod-1].Sold?"is Sold":"is available")}");
}

void ViewAllAvailableProducts()
{
    List<Product> availableProducts=products.Where(p=>!p.Sold).ToList();
    DisplayProduct(availableProducts);
}

void DisplayProduct(List<Product> productList)
{
    for(int i=0;i<productList.Count;i++)
    {
        Console.WriteLine($"{i+1}. The {productList[i].Name} price is {productList[i].Price} dollar and {(productList[i].Sold?"is Sold":"is available")} from {productList[i].DaysOnShelf} days.");
    }
} 