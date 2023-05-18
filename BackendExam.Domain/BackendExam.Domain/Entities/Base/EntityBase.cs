using System.ComponentModel.DataAnnotations;

namespace BackendExam.Domain.Entities.Base
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
