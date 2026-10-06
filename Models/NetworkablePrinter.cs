using Bai05.Enums;
using Bai05.Interfaces;
namespace Bai05.Models;

public class NetworkablePrinter : Printer, INetworkable
{
    private bool _networkable = true;
    private string _ipAddress = string.Empty;

    private bool _isConnected = false;

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
    }

    public void Disconnect()
    {
        IpAddress = string.Empty;
        IsConnected = false;
    }
    public NetworkablePrinter(string deviceId, string deviceName, int commissionYear, double price, PrinterType printerType, string ipAddress)
        : base(deviceId, deviceName, commissionYear, price, printerType)
    {
        IpAddress = ipAddress;
    }

    public override double CalculateEstimatedAnnualMaintenanceCosts()
    {
        return Price * 0.04 + (NumberOfPagesPrinted > 100000 ? 500000 : 0) + (PrinterType == PrinterType.Laser ? 300000 : 0);
    }

    ~NetworkablePrinter()
    {
        Console.WriteLine($"Destructor DeviceId {DeviceId}.");
    }
}