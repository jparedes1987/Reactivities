namespace Domain
{
    public class Activity // Entity or Model Entity Framework
    {
        public Guid Id { get; set; } //Entity framework identifies this as primary key so name is important
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}