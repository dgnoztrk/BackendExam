namespace BackendExam.ApplicationContract.Dto
{
    public class WorkLogDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public EmployeeDto Employee { get; set; }
    }
}
