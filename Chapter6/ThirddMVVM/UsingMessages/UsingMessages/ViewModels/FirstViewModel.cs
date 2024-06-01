using CommunityToolkit.Mvvm.Messaging;
using UsingMessages.Models;

namespace UsingMessages.ViewModels;

public class FirstViewModel
{
#nullable enable
    IMessenger? messenger => Startup.ServiceProvider.GetService<IMessenger>();
#nullable disable

    bool engineRunning;

    public bool EngineRunning
    {
        get => engineRunning;
        set
        {
            if (engineRunning != value)
            {
                engineRunning = value;
                messenger?.Send(new BooleanMessage { BoolValue = value, Message = "EngineRunning" });
            }
        }
    }

    double engineLitres;

    public double EngineLitres
    {
        get => engineLitres;
        set
        {
            if (engineLitres != value)
            {
                engineLitres = value;
                messenger?.Send(new DoubleMessage { DoubleValue = value, Message = "EngineSize" });
            }
        }
    }

    string busMake;

    public string BusMake
    {
        get => busMake;
        set
        {
            if (busMake != value)
            {
                busMake = value;
                messenger?.Send(new StringMessage { Message = value, Sender = "BusMake" });
                messenger.Send(value, "BusMake");
                messenger.Send(new StringMessage { Message = value, Sender = "BusMake" }, "BusMake");
            }
        }
    }

    int numberOfSeats;

    public int NumberOfSeats
    {
        get => numberOfSeats;
        set
        {
            if (numberOfSeats != value)
            {
                numberOfSeats = value;
                messenger?.Send(new IntMessage { IntValue = value, Message = "NumberOfSeats" });
            }
        }
    }

    public void MoveToSecondView()
    {
        Shell.Current.GoToAsync("//SecondPage");
    }
}