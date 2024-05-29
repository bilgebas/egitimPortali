namespace egitimPortali.Models
{
    public class Participation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int EducationId { get; set; }
        public Education Education { get; set; }
        public bool IsCanceled { get; set; }
    }
}
