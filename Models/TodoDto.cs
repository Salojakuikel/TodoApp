namespace TODOApp.Models
{
    public class TodoDto
    {
        public Guid Id { get; set; }
        public bool status { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDate  { get; set; }
    }
}
