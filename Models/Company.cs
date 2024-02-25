using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public class Company : BaseClass
    {
        public string? Name { get; set; }
        public string? Phonenumber { get; set; }
        public string? Email { get; set; }
        public string? Logo { get; set; }
        public string? Address { get; set; }
        public bool IsVisibility { get; set; }
        public List<Worker>? Workers { get; set; }

        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        public List<Service>? Services { get; set; }
        public List<CompanyOpenHours>? CompanyOpenHours { get; set; }
        public List<CompanyImage>? CompanyImages { get; set; }
        public List<CompanyLike>? LikedByUsers { get; set; }

    }
}