namespace Bai05.Models;

using Bai05.Interfaces;

public class Computer : Device, INetworkable
{
    private string _memory = string.Empty;
    private string _processorType = string.Empty;
    private bool _hasDedicatedGraphicsCard;
    private string _ipAddress = string.Empty;

    private bool _isConnected;



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

    public string IpAddress
    {
        get => _ipAddress;
        set => _ipAddress = value;
    }

    public bool IsConnected
    {
        get => _isConnected;
        set => _isConnected = value;
    }

    public Computer(string deviceId, string deviceName, int commissionYear, double price, string memory, string processorType, bool hasDedicatedGraphicsCard)
        : base(deviceId, deviceName, commissionYear, price)
    {
        Memory = memory;
        ProcessorType = processorType;
        HasDedicatedGraphicsCard = hasDedicatedGraphicsCard;
        IsConnected = true;
    }

    public override double CalculateEstimatedAnnualMaintenanceCosts()
    {
        int thisYear = DateTime.Now.Year;
        return Price * 0.05 + (HasDedicatedGraphicsCard ? Price * 0.02 : 0) + (thisYear - CommissionYear > 5 ? Price * 0.01 : 0);
    }

    public void Connect(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress))
        {
            throw new ArgumentException("Địa chỉ IP không được để trống.", nameof(ipAddress));
        }
        if (IsConnected)
        {
            throw new InvalidOperationException("Máy in đã kết nối.");
        }
        IpAddress = ipAddress;
        IsConnected = true;
        Console.WriteLine($"Kết nối mạng thành công.");
    }

    public void Disconnect()
    {
        IpAddress = string.Empty;
        IsConnected = false;
    }


    ~Computer()
    {
        Console.WriteLine($"Destructor DeviceId {DeviceId}.");
    }
}