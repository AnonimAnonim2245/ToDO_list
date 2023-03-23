using CommunityToolkit.Mvvm.Messaging.Messages;

namespace tema4_2.Messages;

public class DeleteItemMessage : ValueChangedMessage<string>
{
    public DeleteItemMessage(string value) : base(value)
    {

    }
}