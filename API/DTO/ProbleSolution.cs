namespace API.DTO
{
    public class ProbleSolution
    {
        public int dto_Id { get; set; }
        public string dto_ProbleName { get; set; }
        public string dto_ProblemDescription { get; set; }
        public string dto_SolutionName { get; set; }
        public string dto_SolutionDescription { get; set; }
        public DateTime dto_CreatedOn { get; set; }
        public string dto_CreatedBy { get; set; }
        public DateTime dto_ModifiedOn { get; set; }
        public string dto_ModifiedBy { get; set; }
    }
}
