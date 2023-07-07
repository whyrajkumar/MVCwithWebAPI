using System.ComponentModel.DataAnnotations;

namespace MVCwithWebAPI.Models
{
    public class Employee
    {
        public string Id { get; set; }
        //[Required(ErrorMessage = "*")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "*")]
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
    }
}