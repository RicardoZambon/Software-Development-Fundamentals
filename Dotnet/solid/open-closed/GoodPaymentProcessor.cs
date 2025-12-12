// ✅ GOOD EXAMPLE — Open/Closed Principle Applied
// New payment methods can be added without modifying existing, stable code.

#region Domain

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

#endregion

#region Abstractions

public interface IPaymentFeeStrategy
{
    PaymentMethod Method { get; }
    decimal Calculate(Payment payment);
}

#endregion

#region Strategies

public class CreditCardFeeStrategy : IPaymentFeeStrategy
{
    public PaymentMethod Method => PaymentMethod.CreditCard;

    public decimal Calculate(Payment payment)
        => payment.Amount * 0.03m;
}

public class PayPalFeeStrategy : IPaymentFeeStrategy
{
    public PaymentMethod Method => PaymentMethod.PayPal;

    public decimal Calculate(Payment payment)
        => payment.Amount * 0.05m;
}

public class PixFeeStrategy : IPaymentFeeStrategy
{
    public PaymentMethod Method => PaymentMethod.Pix;

    public decimal Calculate(Payment payment)
        => 0m;
}

#endregion

#region Processor

public class PaymentProcessor
{
    private readonly IReadOnlyDictionary<PaymentMethod, IPaymentFeeStrategy> _strategies;

    public PaymentProcessor(IEnumerable<IPaymentFeeStrategy> strategies)
    {
        _strategies = strategies.ToDictionary(s => s.Method);
    }

    public decimal CalculateFee(Payment payment)
    {
        if (!_strategies.TryGetValue(payment.Method, out var strategy))
            throw new NotSupportedException("Payment method not supported");

        return strategy.Calculate(payment);
    }
}

#endregion

// Benefits:
// - PaymentProcessor remains unchanged when new methods are added
// - Each strategy has a single responsibility
// - Easy to test strategies independently
// - OCP is enforced through extension, not modification
