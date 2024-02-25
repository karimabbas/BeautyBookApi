using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public class CompanyImage : BaseClass
    {
        public string? Path { get; set; }
               
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
    }
}