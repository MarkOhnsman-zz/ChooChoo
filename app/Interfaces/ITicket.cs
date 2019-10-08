namespace tickets.Interfaces
{
    public interface ITicket
    {
        string Title { get; }
        string Description { get; set; }

        string GetTemplate();
    }
}