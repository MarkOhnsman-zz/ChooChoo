using System;

namespace tickets.Models
{
    public class Message
    {
        public Message(ConsoleColor color, string content)
        {
            this.Color = color;
            this.Content = content;

        }
        public ConsoleColor Color { get; set; }
        public string Content { get; set; }
    }
}