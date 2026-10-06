using Bai05.Enums;
namespace Bai05.Models;

public class Projector : Device
{

    private int _lumens = 0;
    private int _usedHours = 0;

    public int Lumens
    {
        get => _lumens;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _lumens = value;
        }
    }

    public int UsedHours
    {
        get => _usedHours;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _usedHours = value;
        }
    }




    public Projector(string deviceId, string deviceName, int commissionYear, double price, int lumens, int usedHours)
        : base(deviceId, deviceName, commissionYear, price)
    {
        Lumens = lumens;
        UsedHours = usedHours;
    }

    public override double CalculateEstimatedAnnualMaintenanceCosts()
    {
        return Price * 0.05 + (UsedHours > 3000 ? 1500000 : 0);
    }

    ~Projector()
    {
        Console.WriteLine($"Destructor DeviceId {DeviceId}.");
    }
}