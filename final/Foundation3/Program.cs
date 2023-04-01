using System;

class Program
{
    static void Main(string[] args)
    {
        Address lectureAddress = new Address("123 Lecture St", "New York", "NY", "10001");
        Address receptionAddress = new Address("456 Reception Ave", "Los Angeles", "CA", "90001");
        Address outdoorGatheringAddress = new Address("789 Gathering Park", "Chicago", "IL", "60601");

        Lecture lectureEvent = new Lecture(
            "AI in Healthcare",
            "Learn about the latest advancements in AI for healthcare applications.",
            DateTime.Parse("04-15-2023"),
            DateTime.Parse("14:00"),
            lectureAddress,
            "Dr. Jane Smith",
            100
        );

        Reception receptionEvent = new Reception(
            "Tech Networking Night",
            "Join us for an evening of networking with professionals in the tech industry.",
            DateTime.Parse("04-20-2023"),
            DateTime.Parse("18:00"),
            receptionAddress,
            "rsvp@tech-networking-night.com"
        );

        OutdoorGathering outdoorGatheringEvent = new OutdoorGathering(
            "Outdoor Yoga Retreat",
            "A relaxing day of outdoor yoga and meditation sessions.",
            DateTime.Parse("04-25-2023"),
            DateTime.Parse("09:00"),
            outdoorGatheringAddress,
            "Sunny with a high of 75°F"
        );

        DisplayEventDetails(lectureEvent);
        DisplayEventDetails(receptionEvent);
        DisplayEventDetails(outdoorGatheringEvent);
    }

    private static void DisplayEventDetails(Event eventInstance)
    {
        Console.WriteLine("Standard Details:");
        Console.WriteLine(eventInstance.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("Full Details:");
        Console.WriteLine(eventInstance.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("Short Description:");
        Console.WriteLine(eventInstance.GetShortDescription());
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------");
    }
}
