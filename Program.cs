// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

// Step 1: Define the abstract class
public abstract class CustomService
{
    public abstract void DoSomething();
}

// Step 2: Implement the custom service
public class CustomServiceImpl1 : CustomService
{
    public override void DoSomething()
    {
        Console.WriteLine("Custom Service Implementation 1 - Retrieve data from my server!");
    }
}

public class CustomServiceImpl2 : CustomService
{
    public override void DoSomething()
    {
        Console.WriteLine("Custom Service Implementation 2 - Connected to my server!");
    }
}

// Step 3: Register the custom service
public class CustomServiceRegistry
{
    private static readonly Lazy<CustomService> Service1 = new Lazy<CustomService>(() => new CustomServiceImpl1());
    private static readonly Lazy<CustomService> Service2 = new Lazy<CustomService>(() => new CustomServiceImpl2());

    public static CustomService GetService(string serviceName)
    {
        switch (serviceName)
        {
            case "service1":
                return Service1.Value;
            case "service2":
                return Service2.Value;
            default:
                throw new ArgumentException($"Service with name '{serviceName}' is not registered.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string serviceName = "service1"; // Change this to "service2" to use the other implementation
        CustomService service = CustomServiceRegistry.GetService(serviceName);
        service.DoSomething();
        Console.ReadLine();
    }

}