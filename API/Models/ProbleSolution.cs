namespace API.Models
{
    public class ProbleSolution
    {
        public int Id { get; set; }
        public string ProbleName { get; set; }
        public string ProblemDescription { get; set; }
        public string SolutionName {  get; set; }
        public string SolutionDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
