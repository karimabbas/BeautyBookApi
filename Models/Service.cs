using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public class Service : BaseClass
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

    }
}