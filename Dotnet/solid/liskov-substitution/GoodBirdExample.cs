// ✅ GOOD EXAMPLE — Liskov Substitution Principle Applied
// The abstraction models reality correctly and guarantees safe polymorphism.

#region Abstractions

public abstract class Bird
{
    public abstract void Move();
}

public interface IFlyingBird
{
    void Fly();
}

#endregion

#region Implementations

public class Sparrow : Bird, IFlyingBird
{
    public override void Move()
    {
        Console.WriteLine("Sparrow is hopping");
    }

    public void Fly()
    {
        Console.WriteLine("Sparrow is flying");
    }
}

public class Penguin : Bird
{
    public override void Move()
    {
        Console.WriteLine("Penguin is swimming");
    }
}

#endregion

#region Services

public class BirdService
{
    public void MakeBirdMove(Bird bird)
    {
        // Safe polymorphism: all birds can move
        bird.Move();
    }

    public void MakeBirdFly(IFlyingBird bird)
    {
        // Only flying birds are allowed here
        bird.Fly();
    }
}

#endregion

// Benefits:
// - No runtime surprises
// - Clear behavioral contracts
// - Correct modeling of the domain
// - LSP is enforced by design
