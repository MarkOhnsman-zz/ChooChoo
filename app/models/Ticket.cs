using System;
using tickets.Interfaces;

namespace tickets.Models
{
    class Ticket : ITicket
    {
        public string Title { get; private set; }
        public string Description { get; set; }

        public string GetTemplate()
        {
            return $"Title: {Title}\nDescription: {Description}";
        }

        public Ticket(string title, string desc)
        {
            Title = title;
            Description = desc;
        }
    }
}