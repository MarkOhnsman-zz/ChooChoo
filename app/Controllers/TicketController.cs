using System;
using tickets.Models;
using tickets.Services;

namespace tickets.Controllers
{
    public class TicketController
    {
        TicketService _ticketService = new TicketService();
        public void Run()
        {
            while (true)
            {
                _ticketService.GetTickets();
                Update();
                GetUserInput();
            }
        }

        private void Update()
        {
            Console.Clear();
            foreach (Message m in _ticketService.Messages)
            {
                Console.ForegroundColor = m.Color;
                Console.WriteLine(m.Content);
            }
            _ticketService.Messages.Clear();
            Console.ResetColor();
        }

        private void GetUserInput()
        {
            Console.WriteLine("What Would you like to do? (view, new, quit)");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "view":
                    ViewDetails();
                    break;
                case "new":
                    NewTicket();
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    _ticketService.Messages.Add(new Message(ConsoleColor.Red, "Invalid selection"));
                    break;
            }
        }
        private void ViewDetails()
        {
            Console.Write("Which Ticket? ");
            string index = Console.ReadLine();
            _ticketService.GetTickets(index);
            Update();
            Console.WriteLine("Press 'C' to close or any other key to return to the main menu");
            var input = Console.ReadKey();
            if (input.KeyChar == 'c')
            {
                _ticketService.CloseTicket(index);
            }
        }

        private void NewTicket()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            _ticketService.NewTicket(title, description);
        }

    }
}

