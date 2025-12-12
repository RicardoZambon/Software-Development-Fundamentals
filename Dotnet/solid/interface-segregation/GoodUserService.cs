// ✅ GOOD EXAMPLE — Interface Segregation Principle Applied
// Clients depend only on the interfaces they actually need.

#region Domain

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
}

#endregion

#region Segregated Interfaces

public interface IUserReader
{
    User GetById(int id);
}

public interface IUserWriter
{
    void Create(User user);
    void Update(User user);
    void Delete(int id);
}

public interface IUserNotifier
{
    void SendPasswordResetEmail(User user);
}

public interface IUserReporting
{
    byte[] GenerateMonthlyReport(int month, int year);
}

#endregion

#region Implementations

public class UserRepository : IUserReader, IUserWriter
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
}

public class UserEmailNotifier : IUserNotifier
{
    public void SendPasswordResetEmail(User user)
    {
        // email logic
    }
}

public class UserReportService : IUserReporting
{
    public byte[] GenerateMonthlyReport(int month, int year)
    {
        // reporting logic
        return Array.Empty<byte[]>();
    }
}

#endregion

#region Clients

// Client depends only on what it needs
public class UserProfileReader
{
    private readonly IUserReader _userReader;

    public UserProfileReader(IUserReader userReader)
    {
        _userReader = userReader;
    }

    public User GetProfile(int userId)
    {
        return _userReader.GetById(userId);
    }
}

#endregion

// Benefits:
// - Clients depend only on relevant behavior
// - Changes are isolated
// - Smaller, focused mocks in tests
// - Interfaces reflect clear roles
