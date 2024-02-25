using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public class Location : BaseClass
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        public List<Company>? Companies {get;set;}
    }
}