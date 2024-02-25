using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public class CompanyLike : BaseClass
    {
        [ForeignKey("UserId")]
        public BaseUser? User { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
    }
}