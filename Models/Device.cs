using Bai05.Enums;
namespace Bai05.Models;

public abstract class Device
{
    private string _deviceId = string.Empty;
    private string _deviceName = string.Empty;
    private int _commissionYear;
    private double _price;
    private DeviceStatus _status = DeviceStatus.Active;

    public string DeviceId
    {
        get => _deviceId;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            _deviceId = value;
        }
    }

    public string DeviceName
    {
        get => _deviceName;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            _deviceName = value;
        }
    }

    public int CommissionYear
    {
        get => _commissionYear;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            int thisYear = DateTime.Now.Year;
            if (value > thisYear)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Năm đưa vào sử dụng không được lớn hơn năm hiện tại.");
            }
            _commissionYear = value;
        }
    }

    public double Price
    {
        get => _price;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            _price = value;
        }
    }

    public DeviceStatus Status
    {
        get => _status;
        set
        {
            _status = value;
        }
    }

    public Device(string deviceId, string deviceName, int commissionYear, double price)
    {
        DeviceId = deviceId;
        DeviceName = deviceName;
        CommissionYear = commissionYear;
        Price = price;
    }

    public abstract double CalculateEstimatedAnnualMaintenanceCosts();
    public override string ToString()
    {
        return $"DeviceId: {DeviceId}, DeviceName: {DeviceName}, CommissionYear: {CommissionYear}, Price: {Price}, Status: {Status}";
    }

    ~Device()
    {
        Console.WriteLine($"Destructor DeviceId {DeviceId}.");
    }
}