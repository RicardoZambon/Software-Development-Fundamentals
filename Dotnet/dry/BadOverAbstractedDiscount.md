// ❌ BAD EXAMPLE — DRY Misapplied (Over-Abstracted)
// This helper centralizes too much knowledge behind flags and parameters,
// hiding intent and creating a change hotspot.

public enum CustomerType
{
    Regular,
    Premium,
    Employee
}

public static class DiscountCalculator
{
    public static decimal Calculate(
        decimal amount,
        CustomerType customerType,
        bool isHoliday,
        bool isFirstPurchase,
        int loyaltyYears)
    {
        // Employee discount overrides everything
        if (customerType == CustomerType.Employee)
            return amount * 0.30m;

        // Holiday + Premium combo
        if (customerType == CustomerType.Premium && isHoliday)
            return amount * 0.20m;

        // Loyalty-based discount
        if (loyaltyYears >= 5)
            return amount * 0.15m;

        // First purchase incentive
        if (isFirstPurchase)
            return amount * 0.10m;

        // Default premium discount
        if (customerType == CustomerType.Premium)
            return amount * 0.05m;

        return 0m;
    }
}

// Problems:
// - Business rules are encoded as flags and ordering
// - Call sites lack clarity (what does each flag mean here?)
// - Every new rule modifies this method (OCP violation)
// - Hard to test edge cases independently
// - Centralized logic becomes a fragile change hotspot
