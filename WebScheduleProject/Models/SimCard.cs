namespace WebScheduleProject.Models
{
    public class SimCard
    {
        public int Id { get; set; }
        public char? Number { get; set; }
        public List<string>? Services { get; set; }
        public string? Provider { get; set; }
    }
}
