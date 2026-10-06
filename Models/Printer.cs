using Bai05.Enums;
namespace Bai05.Models;

public class Printer : Device
{
    private PrinterType _printerType;

    private int _numberOfPagesPrinted = 0;

    public bool Networkable { get; protected set; } = false;


    public PrinterType PrinterType
    {
        get => _printerType;
        set
        {
            _printerType = value;
        }
    }

    public int NumberOfPagesPrinted
    {
        get => _numberOfPagesPrinted;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _numberOfPagesPrinted = value;
        }
    }


    public Printer(string deviceId, string deviceName, int commissionYear, double price, PrinterType printerType, int numberOfPagesPrinted = 0)
        : base(deviceId, deviceName, commissionYear, price)
    {
        PrinterType = printerType;
        NumberOfPagesPrinted = numberOfPagesPrinted;
    }

    public override double CalculateEstimatedAnnualMaintenanceCosts()
    {
        return Price * 0.04 + (NumberOfPagesPrinted > 100000 ? 500000 : 0) + (PrinterType == PrinterType.Laser ? 300000 : 0);
    }

    ~Printer()
    {
        Console.WriteLine($"Destructor DeviceId {DeviceId}.");
    }
}