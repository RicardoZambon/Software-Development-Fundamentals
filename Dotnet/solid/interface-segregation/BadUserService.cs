// ❌ BAD EXAMPLE — Interface Segregation Principle Violation
// A fat interface forces clients to depend on methods they do not use.

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
}

public interface IUserService
{
    User GetById(int id);
    void Create(User user);
    void Update(User user);
    void Delete(int id);

    // Unrelated responsibilities
    void SendPasswordResetEmail(User user);
    byte[] GenerateMonthlyReport(int month, int year);
}

// Client that only needs read access
public class UserProfileReader
{
    private readonly IUserService _userService;

    public UserProfileReader(IUserService userService)
    {
        _userService = userService;
    }

    public User GetProfile(int userId)
    {
        return _userService.GetById(userId);
    }
}

// Implementation is forced to support everything
public class UserService : IUserService
{
    public User GetById(int id)
    {
        return new User { Id = id, Email = "user@email.com" };
    }

    public void Create(User user)
    {
        // create logic
    }

    public void Update(User user)
    {
        // update logic
    }

    public void Delete(int id)
    {
        // delete logic
    }

    public void SendPasswordResetEmail(User user)
    {
        // email logic
    }

    public byte[] GenerateMonthlyReport(int month, int year)
    {
        // reporting logic
        return Array.Empty<byte[]>();
    }
}

// Problems:
// - Clients depend on methods they don't use
// - Changes to reporting/email impact all consumers
// - Testing requires mocking irrelevant methods
// - Interface violates cohesion
