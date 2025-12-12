// ❌ BAD EXAMPLE — Liskov Substitution Principle Violation
// The base abstraction promises behavior that not all subtypes can honor.

public abstract class Bird
{
    public abstract void Fly();
}

public class Sparrow : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow is flying");
    }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        // LSP violation: this subtype cannot honor the base contract
        throw new NotSupportedException("Penguins cannot fly");
    }
}

public class BirdService
{
    public void MakeBirdFly(Bird bird)
    {
        // Caller trusts the base contract
        bird.Fly();
    }
}

// Problems:
// - Bird promises that all birds can fly
// - Penguin breaks the behavioral contract
// - Code compiles but fails at runtime
// - Polymorphism becomes unsafe
