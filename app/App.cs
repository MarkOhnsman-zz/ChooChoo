using System;
using tickets.Models;

namespace tickets
{
    class App
    {
        TicketSystem ticketSystem;
        Boolean active;
        public void Run()
        {
            ticketSystem = new TicketSystem();
            active = true;
            Console.Clear();
            Console.WriteLine("Welcome to the Ticket System");
            ticketSystem.PrintAll();
            while (active)
            {
                Console.WriteLine("What would you like to do? (view / new / quit)");
                string choice = Console.ReadLine();
                makeSelection(choice);
            }
        }
        public void makeSelection(string choice)
        {
            switch (choice.ToLower())
            {
                case "view":
                    Console.Write("Which Ticket? ");
                    string index = Console.ReadLine();
                    Console.Clear();
                    ticketSystem.ViewTicket(index);
                    break;
                case "new":
                    ticketSystem.NewTicket();
                    break;
                case "quit":
                    active = false;
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }
        }

    }
}