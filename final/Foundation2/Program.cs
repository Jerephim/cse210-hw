using System;

public class Product
{
    private string name;
    private int id;
    private double price;
    private int quantity;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public Product(string name, int id, double price, int quantity)
    {
        Name = name;
        Id = id;
        Price = price;
        Quantity = quantity;
    }
}
public class Customer
{
    private string name;
    private Address address;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Address Address
    {
        get { return address; }
        set { address = value; }
    }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsUSCustomer()
    {
        return Address.IsInUSA();
    }
}
public class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public string StreetAddress
    {
        get { return streetAddress; }
        set { streetAddress = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    public Address(string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country == "USA";
    }

    public string GetFullAddress()
    {
        return StreetAddress + "\n" + City + ", " + State + "\n" + Country;
    }
}
public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;

        foreach (Product product in products)
        {
            totalPrice += product.Price * product.Quantity;
        }

        if (customer.IsUSCustomer())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string label = "";

        foreach (Product product in products)
        {
            label += product.Quantity + " " + product.Name +  " (ID: " + product.Id + ")\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return customer.Name + "\n" + customer.Address.GetFullAddress();
    }
}
class Program{

    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Address address2 = new Address("456 E St", "Sometown", "NY", "USA");
        Customer customer2 = new Customer("John Doe", address2);

        List<Product> products1 = new List<Product>()
        {
            new Product("Wireless Headphones", 2950, 79.99, 2),
            new Product("Smartwatch", 8912, 149.99, 3),
            new Product("Gaming Mouse", 7019, 39.99, 1)
        };
    
        Order order1 = new Order(products1, customer1);
    
        string packingLabel1 = order1.GetPackingLabel();
        string shippingLabel1 = order1.GetShippingLabel();
        double totalPrice1 = order1.GetTotalPrice();
    
        List<Product> products2 = new List<Product>()
        {
            new Product("Bluetooth Speaker", 4829, 99.99, 2),
            new Product("Laptop Backpack", 8123, 49.99, 2)
        };

        Order order2 = new Order(products2, customer2);

        string packingLabel2 = order2.GetPackingLabel();
        string shippingLabel2 = order2.GetShippingLabel();
        double totalPrice2 = order2.GetTotalPrice();

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:\n" + packingLabel1);
        Console.WriteLine("Shipping Label:\n" + shippingLabel1);
        Console.WriteLine("Total Price: $" + totalPrice1);
    
        Console.WriteLine();
    
        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:\n" + packingLabel2);
        Console.WriteLine("Shipping Label:\n" + shippingLabel2);
        Console.WriteLine("Total Price: $" + totalPrice2);
    }
}