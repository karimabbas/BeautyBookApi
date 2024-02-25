using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public class Appointment : BaseClass
    {
        public DateTime Date { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public string? Note { get; set; }
        public AppointmentStatus? Status {get;set;}
    }
}