using System;
using tickets.Controllers;
using tickets.Models;

namespace tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            new TicketController().Run();
        }
    }
}
