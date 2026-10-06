namespace Bai05.Models;

public class Computer : Device
{
    private string _memory = string.Empty;
    private string _processorType = string.Empty;
    private bool _hasDedicatedGraphicsCard;

    public string Memory
    {
        get => _memory;
        set
        {
            _memory = value;
        }
    }

    public string ProcessorType
    {
        get => _processorType;
        set
        {
            _processorType = value;
        }
    }

    public bool HasDedicatedGraphicsCard
    {
        get => _hasDedicatedGraphicsCard;
        set
        {
            _hasDedicatedGraphicsCard = value;
        }
    }

    public Computer(string deviceId, string deviceName, int commissionYear, double price, string memory, string processorType, bool hasDedicatedGraphicsCard)
        : base(deviceId, deviceName, commissionYear, price)
    {
        Memory = memory;
        ProcessorType = processorType;
        HasDedicatedGraphicsCard = hasDedicatedGraphicsCard;
    }

    public override double CalculateEstimatedAnnualMaintenanceCosts()
    {
        int thisYear = DateTime.Now.Year;
        return Price * 0.05 + (HasDedicatedGraphicsCard ? Price * 0.02 : 0) + (thisYear - CommissionYear > 5 ? Price * 0.01 : 0);
    }

    ~Computer()
    {
        Console.WriteLine($"Destructor DeviceId {DeviceId}.");
    }
}