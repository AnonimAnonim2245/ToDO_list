using CommunityToolkit.Mvvm.Messaging.Messages;

namespace tema4_2.Messages;

public class AddItemMessage : ValueChangedMessage<string>
{
    public AddItemMessage(string value) : base(value)
    {

    }
}