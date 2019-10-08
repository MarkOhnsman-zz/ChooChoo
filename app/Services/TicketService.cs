using System;
using System.Collections.Generic;
using tickets.Interfaces;
using tickets.Models;

namespace tickets.Services
{
    public class TicketService
    {
        private List<ITicket> Tickets { get; set; }
        public List<Message> Messages { get; set; }

        public void GetTickets()
        {
            string template = "Number\t\tTitle\n----------------------------\n";
            for (int i = 0; i < Tickets.Count; i++)
            {
                template += (i + 1) + ".\t\t" + Tickets[i].Title;
            }
            Messages.Add(new Message(ConsoleColor.DarkGreen, template));
        }
        public void GetTickets(string index)
        {
            if (Int32.TryParse(index, out int i))
            {
                i = i - 1;
                if (i > -1 && i < Tickets.Count)
                {
                    Messages.Add(new Message(ConsoleColor.Black, Tickets[i].GetTemplate()));
                    return;
                }
            }
            Messages.Add(new Message(ConsoleColor.Red, "Invalid Ticket Id"));
        }
        public void NewTicket(string title, string description)
        {
            Ticket userTicket = new Ticket(title, description);
            Tickets.Add(userTicket);
            Messages.Add(new Message(ConsoleColor.Green, "Successfully Created"));
        }
        public void CloseTicket(string index)
        {
            if (Int32.TryParse(index, out int i))
            {
                i = i - 1;
                if (i > -1 && i < Tickets.Count)
                {
                    Tickets.RemoveAt(i);
                    Messages.Add(new Message(ConsoleColor.Green, "Successfully Removed"));
                    return;
                }
            }
            Messages.Add(new Message(ConsoleColor.Red, "Invalid Ticket Id"));
        }

        public TicketService()
        {
            Tickets = new List<ITicket>();
            Messages = new List<Message>();
        }

    }
}