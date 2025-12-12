// ❌ BAD EXAMPLE — Single Responsibility Principle Violation
// This class has multiple reasons to change:
// - Business rules (validation)
// - Persistence (database)
// - Infrastructure (email)
// - Cross-cutting concerns (logging)

public class InvoiceService
{
    public void CreateInvoice(Invoice invoice)
    {
        Validate(invoice);
        SaveToDatabase(invoice);
        SendEmail(invoice);
        Log(invoice);
    }

    private void Validate(Invoice invoice)
    {
        if (invoice.Total <= 0)
            throw new InvalidOperationException("Invoice total must be greater than zero");

        if (string.IsNullOrWhiteSpace(invoice.CustomerEmail))
            throw new InvalidOperationException("Customer email is required");
    }

    private void SaveToDatabase(Invoice invoice)
    {
        // Simulated persistence logic
        Console.WriteLine("Saving invoice to database");
    }

    private void SendEmail(Invoice invoice)
    {
        // Simulated email sending
        Console.WriteLine($"Sending invoice email to {invoice.CustomerEmail}");
    }

    private void Log(Invoice invoice)
    {
        // Simulated logging
        Console.WriteLine("Invoice created successfully");
    }
}

public class Invoice
{
    public decimal Total { get; set; }
    public string CustomerEmail { get; set; }
}
