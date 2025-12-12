// ✅ GOOD EXAMPLE — KISS & YAGNI Applied
// The solution is simple, explicit, and solves today's requirements.

#region Domain

public class Message
{
    public string Content { get; set; }
}

#endregion

#region Simple Service

public class MessageService
{
    public void Send(Message message)
    {
        // Simple, explicit behavior
        Console.WriteLine($"Sending EMAIL: {message.Content}");
    }
}

#endregion

// Benefits:
// - Easy to read and understand
// - No unnecessary abstractions
// - Minimal code surface
// - Easy to refactor when a second delivery method is actually needed
// - KISS keeps intent clear
// - YAGNI avoids speculative flexibility
