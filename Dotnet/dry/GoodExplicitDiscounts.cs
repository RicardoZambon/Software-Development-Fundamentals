// ✅ GOOD EXAMPLE — DRY Applied Correctly (Intentional WET)
// Business rules are explicit, readable, and evolve independently.

#region Domain

public class Order
{
    public decimal Amount { get; set; }
    public bool IsHoliday { get; set; }
    public bool IsFirstPurchase { get; set; }
    public int LoyaltyYears { get; set; }
}

#endregion

#region Discount Rules (Explicit Knowledge)

public interface IDiscountRule
{
    decimal Apply(Order order);
}

public class EmployeeDiscountRule : IDiscountRule
{
    public decimal Apply(Order order)
        => order.Amount * 0.30m;
}

public class PremiumHolidayDiscountRule : IDiscountRule
{
    public decimal Apply(Order order)
        => order.IsHoliday ? order.Amount * 0.20m : 0m;
}

public class LoyaltyDiscountRule : IDiscountRule
{
    public decimal Apply(Order order)
        => order.LoyaltyYears >= 5 ? order.Amount * 0.15m : 0m;
}

public class FirstPurchaseDiscountRule : IDiscountRule
{
    public decimal Apply(Order order)
        => order.IsFirstPurchase ? order.Amount * 0.10m : 0m;
}

#endregion

#region Orchestration (Simple and Clear)

public class DiscountService
{
    private readonly IEnumerable<IDiscountRule> _rules;

    public DiscountService(IEnumerable<IDiscountRule> rules)
    {
        _rules = rules;
    }

    public decimal CalculateDiscount(Order order)
    {
        // Explicit rule evaluation — easy to read and test
        return _rules.Sum(rule => rule.Apply(order));
    }
}

#endregion

// Benefits:
// - Business knowledge is explicit and discoverable
// - Rules can evolve independently
// - Easy to test each rule in isolation
// - New rules added without modifying existing ones (OCP)
// - No hidden flags or parameter soup
