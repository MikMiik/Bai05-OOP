/*
Mã sinh viên: 202418946
Họ tên: Phạm Văn Minh
*/

using Bai05.Models;
using Bai05.Enums;

Computer computer1 = new("C001", "Dell", 2024, 25000000, memory: "16GB", processorType: "Intel Core i7", hasDedicatedGraphicsCard: false);
Computer computer2 = new("C002", "ASUS", 2025, 15000000, memory: "16GB", processorType: "Apple M1", hasDedicatedGraphicsCard: true);
Printer printer1 = new("P001", "Canon", 2023, 100000, printerType: PrinterType.Laser, numberOfPagesPrinted: 10);
Printer printer2 = new("P001", "Canon", 2023, 200000, printerType: PrinterType.Inkjet, numberOfPagesPrinted: 10);
