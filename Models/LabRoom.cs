using Bai05.Enums;
namespace Bai05.Models;

public class LabRoom
{
    private string _labRoomId = string.Empty;
    private string _labRoomName = string.Empty;
    private int _capacity = 0;
    public List<Device> Devices { get; } = new();

    public string LabRoomId
    {
        get => _labRoomId;
        set => _labRoomId = value;
    }

    public string LabRoomName
    {
        get => _labRoomName;
        set => _labRoomName = value;
    }

    public int Capacity
    {
        get => _capacity;
        set => _capacity = value;
    }


    public LabRoom(string labRoomId, string labRoomName, int capacity)
    {
        LabRoomId = labRoomId;
        LabRoomName = labRoomName;
        Capacity = capacity;

    }

    public bool AddDevice(Device device)
    {
        ArgumentNullException.ThrowIfNull(device);
        if (Devices.Contains(device))
        {
            throw new InvalidOperationException($"Thiết bị {device.DeviceId} đã tồn tại trong lab.");
        }
        Devices.Add(device);
        Console.WriteLine($"Added device {device.DeviceId} to the lab room {LabRoomName}.");
        return true;
    }



    public Device? FindDevice(string deviceId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(deviceId);
        return Devices.FirstOrDefault(d => d.DeviceId.Equals(deviceId, StringComparison.OrdinalIgnoreCase));

    }

    public decimal CalculateAnnualMaintenanceCost()
    {
        decimal totalCost = 0;
        foreach (var device in Devices)
        {
            totalCost += device.CalculateEstimatedAnnualMaintenanceCosts();
        }
        return totalCost;
    }

    public List<Device> GetDevicesRequiringMaintenance()
    {
        return [.. Devices.Where(d => d.Status == DeviceStatus.UnderMaintenance)];
    }

    ~LabRoom()
    {
        Console.WriteLine($"Destructor LabRoomId {LabRoomId}.");
    }
}