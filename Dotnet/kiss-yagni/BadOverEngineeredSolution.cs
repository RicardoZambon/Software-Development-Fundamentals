// ❌ BAD EXAMPLE — KISS & YAGNI Violations
// This solution is over-engineered for the current requirements.
// It introduces abstractions, patterns, and flexibility that are not needed.

#region Domain

public class Message
{
    public string Content { get; set; }
}

#endregion

#region Premature Abstractions

public interface IMessageFormatter
{
    string Format(Message message);
}

public class DefaultMessageFormatter : IMessageFormatter
{
    public string Format(Message message)
    {
        return $"[DEFAULT]: {message.Content}";
    }
}

public interface IMessageSender
{
    void Send(string formattedMessage);
}

public class EmailMessageSender : IMessageSender
{
    public void Send(string formattedMessage)
    {
        Console.WriteLine($"Sending EMAIL: {formattedMessage}");
    }
}

#endregion

#region Orchestration

public class MessageService
{
    private readonly IMessageFormatter _formatter;
    private readonly IMessageSender _sender;

    public MessageService(IMessageFormatter formatter, IMessageSender sender)
    {
        _formatter = formatter;
        _sender = sender;
    }

    public void Send(Message message)
    {
        var formatted = _formatter.Format(message);
        _sender.Send(formatted);
    }
}

#endregion

// Problems:
// - Only one message format exists
// - Only one delivery mechanism exists
// - Abstractions add indirection without value
// - More files, more DI configuration, more complexity
// - Violates YAGNI and ignores KISS
