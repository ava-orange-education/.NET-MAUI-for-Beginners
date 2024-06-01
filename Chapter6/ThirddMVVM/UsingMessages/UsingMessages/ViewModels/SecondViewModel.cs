using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using UsingMessages.Models;

namespace UsingMessages.ViewModels;

public partial class SecondViewModel : ObservableObject
{
    #nullable enable
    IMessenger? messenger => Startup.ServiceProvider.GetService<IMessenger>();
    #nullable  disable

    [ObservableProperty]
    bool engineRunning;

    [ObservableProperty]
    double engineLitres;

    [ObservableProperty]
    string busMake;

    [ObservableProperty]
    int numberOfSeats;

    public SecondViewModel()
    {
        messenger.Register<IntMessage>(this, (obj, message) =>
            {
                if (!string.IsNullOrEmpty(message.Message))
                    NumberOfSeats = message.IntValue;
            });

        messenger.Register<BooleanMessage>(this, (obj, message) =>
        {
            if (!string.IsNullOrEmpty(message.Message))
                EngineRunning = message.BoolValue;
        });

        messenger.Register<StringMessage>(this, (obj, message) =>
            {
                if (!string.IsNullOrEmpty(message.Sender))
                    BusMake = message.Message;
            });

        messenger.Register<DoubleMessage>(this, (obj, message) =>
        {
            if (!string.IsNullOrEmpty(message.Message))
                EngineLitres = message.DoubleValue;
        });
    }
    
    
}