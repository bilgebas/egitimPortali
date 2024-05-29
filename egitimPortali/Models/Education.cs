namespace egitimPortali.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }
        public int Capacity { get; set; }
        public decimal Cost { get; set; }
        public int Duration { get; set; }
    }
}
