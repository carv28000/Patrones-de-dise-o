using System;

// Abstracción
public abstract class RemoteControl
{
    protected IDevice device;

    public RemoteControl(IDevice device)
    {
        this.device = device;
    }

    public void TurnOn()
    {
        device.TurnOn();
    }

    public void TurnOff()
    {
        device.TurnOff();
    }

    public void SetChannel(int channel)
    {
        device.SetChannel(channel);
    }

    public abstract void PrintStatus();
}

// Implementación
public interface IDevice
{
    void TurnOn();
    void TurnOff();
    void SetChannel(int channel);
}

public class TV : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("TV is turned on");
    }

    public void TurnOff()
    {
        Console.WriteLine("TV is turned off");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine("TV channel set to " + channel);
    }
}

public class Radio : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("Radio is turned on");
    }

    public void TurnOff()
    {
        Console.WriteLine("Radio is turned off");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine("Radio frequency set to " + channel);
    }
}

// Implementación concreta de la abstracción
public class AdvancedRemoteControl : RemoteControl
{
    public AdvancedRemoteControl(IDevice device) : base(device) { }

    public void Mute()
    {
        Console.WriteLine("Device muted");
    }

    public override void PrintStatus()
    {
        Console.WriteLine("Advanced Remote Control:");
        device.TurnOn();
        device.SetChannel(5);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IDevice tvDevice = new TV();
        RemoteControl tvRemote = new RemoteControl(tvDevice);

        tvRemote.TurnOn();
        tvRemote.SetChannel(10);
        tvRemote.PrintStatus();

        IDevice radioDevice = new Radio();
        AdvancedRemoteControl radioRemote = new AdvancedRemoteControl(radioDevice);

        radioRemote.TurnOn();
        radioRemote.SetChannel(95);
        radioRemote.Mute();
        radioRemote.PrintStatus();
    }
}
