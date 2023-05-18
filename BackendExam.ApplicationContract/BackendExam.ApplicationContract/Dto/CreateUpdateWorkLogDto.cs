namespace BackendExam.ApplicationContract.Dto
{
    public class CreateUpdateWorkLogDto
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
