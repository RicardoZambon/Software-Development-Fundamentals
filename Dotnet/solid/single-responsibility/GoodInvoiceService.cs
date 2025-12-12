// ✅ GOOD EXAMPLE — Single Responsibility Principle Applied
// Each class has one clear reason to change.
// Responsibilities are separated and composed.

#region Domain

public class Invoice
{
    public decimal Total { get; set; }
    public string CustomerEmail { get; set; }
}

#endregion

#region Abstractions

public interface IInvoiceValidator
{
    void Validate(Invoice invoice);
}

public interface IInvoiceRepository
{
    void Save(Invoice invoice);
}

public interface IInvoiceNotifier
{
    void Notify(Invoice invoice);
}

#endregion

#region Implementations

public class InvoiceValidator : IInvoiceValidator
{
    public void Validate(Invoice invoice)
    {
        if (invoice.Total <= 0)
            throw new InvalidOperationException("Invoice total must be greater than zero");

        if (string.IsNullOrWhiteSpace(invoice.CustomerEmail))
            throw new InvalidOperationException("Customer email is required");
    }
}

public class InvoiceRepository : IInvoiceRepository
{
    public void Save(Invoice invoice)
    {
        // Simulated persistence logic
        Console.WriteLine("Saving invoice to database");
    }
}

public class InvoiceEmailNotifier : IInvoiceNotifier
{
    public void Notify(Invoice invoice)
    {
        // Simulated email sending
        Console.WriteLine($"Sending invoice email to {invoice.CustomerEmail}");
    }
}

#endregion

#region Orchestration Service

public class InvoiceService
{
    private readonly IInvoiceValidator _validator;
    private readonly IInvoiceRepository _repository;
    private readonly IInvoiceNotifier _notifier;

    public InvoiceService(
        IInvoiceValidator validator,
        IInvoiceRepository repository,
        IInvoiceNotifier notifier)
    {
        _validator = validator;
        _repository = repository;
        _notifier = notifier;
    }

    public void CreateInvoice(Invoice invoice)
    {
        _validator.Validate(invoice);
        _repository.Save(invoice);
        _notifier.Notify(invoice);
    }
}

#endregion
