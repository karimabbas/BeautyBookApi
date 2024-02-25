using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public class CompanyOpenHours : BaseClass
    {
        public TimeSpan OpenFrom { get; set; }
        public TimeSpan OpenUntil { get; set; }

        //0 - sunday 6 - saturday
        public byte DayOfWeek { get; set; }

               
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
    }
}