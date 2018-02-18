using System.ComponentModel;

namespace SchedulingApp.Models
{
    public class Worker
    {
        public int ID { get; set; }

        [DisplayName("Employee First Name")]
        public string FirstName { get; set; }

        [DisplayName("Employee Last Name")]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
    }
}