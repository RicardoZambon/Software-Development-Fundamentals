// ❌ BAD EXAMPLE — Open/Closed Principle Violation
// This class must be modified every time a new payment method is added.
// It becomes a hotspot for changes and regressions.

public enum PaymentMethod
{
    CreditCard,
    PayPal,
    Pix
}

public class Payment
{
    public PaymentMethod Method { get; set; }
    public decimal Amount { get; set; }
}

public class PaymentProcessor
{
    public decimal CalculateFee(Payment payment)
    {
        if (payment.Method == PaymentMethod.CreditCard)
            return payment.Amount * 0.03m;

        if (payment.Method == PaymentMethod.PayPal)
            return payment.Amount * 0.05m;

        if (payment.Method == PaymentMethod.Pix)
            return 0m;

        throw new NotSupportedException("Payment method not supported");
    }
}

// Problems:
// - Adding a new payment method requires modifying this class
// - Existing logic is at risk of regression
// - Violates OCP by forcing modification instead of extension
