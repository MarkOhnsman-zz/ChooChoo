using System;
using System.Collections.Generic;

namespace tickets.Models
{
    class TicketSystem
    {
        private List<Ticket> Log { get; set; }

        public void PrintAll()
        {
            Console.WriteLine(@"
 Number         Title
 ----------------------------
            ");
            for (int i = 0; i < Log.Count; i++)
            {
                Console.WriteLine((i + 1) + ".       " + Log[i].Title);
            }

        }
        public void ViewTicket(string index)
        {
            int i;
            if (Int32.TryParse(index, out i))
            {
                i = i - 1;
                if (i > -1 && i < Log.Count)
                {
                    Log[i].PrintDescription();
                    Console.WriteLine("enter 'close' to remove ticket or any other key to go back");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "close")
                    {
                        CloseTicket(i);
                        return;
                    }
                    Console.Clear();
                    PrintAll();
                    return;
                }
            }
            Console.WriteLine("Invalid Selection");
        }
        public void NewTicket()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Ticket userTicket = new Ticket(title, description);
            Log.Add(userTicket);
            Console.Clear();
            Console.WriteLine("Successfully Created");
            PrintAll();
        }
        public void CloseTicket(int index)
        {
            Log.RemoveAt(index);
            Console.Clear();
            Console.WriteLine("Successfully Removed");
            PrintAll();

        }

        public TicketSystem()
        {
            Log = new List<Ticket>();
        }
    }
}