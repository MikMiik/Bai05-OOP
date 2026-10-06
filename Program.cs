/*
Mã sinh viên: 202418946
Họ tên: Phạm Văn Minh
*/

using Bai05.Models;
using Bai05.Enums;

Computer computer1 = new("C1", "Dell", 2024, 25000000, memory: "16GB", processorType: "Intel Core i7", hasDedicatedGraphicsCard: false);
Computer computer2 = new("C2", "ASUS", 2025, 15000000, memory: "16GB", processorType: "Apple M1", hasDedicatedGraphicsCard: true);
Printer printer1 = new("P1", "Printer1", 2023, 100000, printerType: PrinterType.Laser, numberOfPagesPrinted: 10);
NetworkablePrinter printer2 = new("P2", "Printer2", 2021, 200000, printerType: PrinterType.Inkjet, numberOfPagesPrinted: 10, ipAddress: "192.168.1.100");
Projector projector1 = new("PR1", "Projector1", 2022, 5000000, lumens: 3000, usedHours: 4000);
LabRoom labRoom1 = new("LR1", "Lab Room 1", 2);
LabRoom labRoom2 = new("LR2", "Lab Room 2", 3);
// 1.Thêm thiết bị vào phòng. 
Console.WriteLine("1. Thêm thiết bị vào phòng:");
labRoom1.AddDevice(computer1);
// 2.Thử thêm một thiết bị bị trùng mã
Console.WriteLine("2. Thử thêm một thiết bị bị trùng mã:");
try
{
    labRoom1.AddDevice(computer1);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
// 3. In danh sách thiết bị trong từng phòng. 
Console.WriteLine("3. In danh sách thiết bị trong từng phòng:");


