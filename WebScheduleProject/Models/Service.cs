namespace WebScheduleProject.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public List<SimCard> SimCards { get; set; } = new();
    }
}
