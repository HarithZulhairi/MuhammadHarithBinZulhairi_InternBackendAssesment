using System;
using System.Threading.Tasks;

namespace TechnicalAssesmentBackendDeveloper;

public class Booking
{
    // Encapsulation: Use Properties
    public string GuestName { get; private set; }
    public string RoomNumber { get; private set; }
    public DateTime CheckInDate { get; private set; }
    public DateTime CheckOutDate { get; private set; }
    
    // Use decimal for currency
    public decimal RatePerDay { get; private set; }
    public decimal DiscountPercent { get; private set; }
    public decimal TotalAmount { get; private set; }
    public int TotalDays { get; private set; }

    // Make method Async to handle the logging correctly
    public async Task BookRoomAsync(string name, string room, DateTime checkIn, DateTime checkOut, decimal rate, decimal discountPercent)
    {
        GuestName = name;
        RoomNumber = room;
        CheckInDate = checkIn;
        CheckOutDate = checkOut;
        RatePerDay = rate;
        DiscountPercent = discountPercent;

        CalculateBill();

        // Properly await the async log
        await LogBookingDetailsAsync();

        PrintReceipt();
    }

    private void CalculateBill()
    {
        TotalDays = (CheckOutDate - CheckInDate).Days;
        // Ensure at least 1 day charge if checked out same day
        if (TotalDays == 0) TotalDays = 1; 

        decimal subTotal = TotalDays * RatePerDay;
        decimal discountAmount = subTotal * (DiscountPercent / 100);
        TotalAmount = subTotal - discountAmount;
    }

    private void PrintReceipt()
    {
        Console.WriteLine($"\n--- Booking Confirmed ---");
        Console.WriteLine($"Guest: {GuestName}");
        Console.WriteLine($"Room:  {RoomNumber}");
        Console.WriteLine($"Dates: {CheckInDate:d} to {CheckOutDate:d} ({TotalDays} days)");
        Console.WriteLine($"Total: {TotalAmount:C}"); // Formats as currency
    }

    private async Task LogBookingDetailsAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("[System] Booking log saved successfully.");
    }

    public void Cancel()
    {
        GuestName = null;
        RoomNumber = null;
        CheckInDate = DateTime.MinValue;
        CheckOutDate = DateTime.MinValue;
        RatePerDay = 0;
        TotalAmount = 0;

        Console.WriteLine("Booking cancelled.");
    }
}

public static class AppHost
{
    // Main needs to be async Task to await BookRoomAsync
    public static async Task Run(string[] args)
    {
        Booking b = new Booking();
        // Use 'm' suffix for decimals
        await b.BookRoomAsync("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.50m, 10.0m);
        
        // b.Cancel();
    }
}