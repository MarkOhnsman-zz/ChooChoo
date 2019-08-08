using System;

namespace tickets.Models
{
    class Ticket
    {
        public string Title { get; private set; }
        private string Description { get; set; }

        public void PrintDescription()
        {
            Console.WriteLine($@"
Title: {Title}            
Description: {Description}
            ");

        }

        public Ticket(string title, string desc)
        {
            Title = title;
            Description = desc;
        }
    }
}