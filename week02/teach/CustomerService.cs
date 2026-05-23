/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create queue with invalid size and add 11 customers
        // Expected Result: First 10 added, 11th prints "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(0);   // invalid size → defaults to 10
        for (int i = 1; i <= 11; i++)
        {
            Console.WriteLine($"Adding customer {i}");
            cs1.AddNewCustomerForTest($"Name{i}", $"ID{i}", $"Problem{i}");
        }

        // Defect(s) Found: The size check was wrong

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Create queue of size 3 and add 4 customers
        // Expected Result: First 3 added, 4th prints "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(3);
        cs2.AddNewCustomerForTest("A", "1", "P1");
        cs2.AddNewCustomerForTest("B", "2", "P2");
        cs2.AddNewCustomerForTest("C", "3", "P3");
        cs2.AddNewCustomerForTest("D", "4", "P4");   // This should show full message

        // Defect(s) Found: same size bug

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Add 2 customers and serve them
        // Expected Result: Prints customer 1, then customer 2
        Console.WriteLine("Test 3");

        var cs3 = new CustomerService(5);
        cs3.AddNewCustomerForTest("First", "111", "Issue1");
        cs3.AddNewCustomerForTest("Second", "222", "Issue2");
        cs3.ServeCustomer();
        cs3.ServeCustomer();

        // Defect(s) Found: ServeCustomer printed wrong customer

        Console.WriteLine("=================");


        // Test 4
        // Scenario: Serve from empty queue
        // Expected Result: "No customers in queue."
        Console.WriteLine("Test 4");

        var cs4 = new CustomerService(5);
        cs4.ServeCustomer();

        // Defect(s) Found: missing empty check

        Console.WriteLine("=================");

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    // This is a helper for testing (no user input)
    private void AddNewCustomerForTest(string name, string accountId, string problem)
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers in queue.");
            return;
        }

        var customer = _queue[0];   // This will get the first customer
        Console.WriteLine(customer); 
        _queue.RemoveAt(0);         // This will remove after printing
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
