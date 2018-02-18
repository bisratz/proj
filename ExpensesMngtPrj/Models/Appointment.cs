using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchedulingApp.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public Customer customer { get; set; }
        public Worker worker { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayName("Time")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public string Description { get; set; }
    }
}