using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public class Worker : BaseClass
    {
        [ForeignKey("BaseUserId")]
        public BaseUser? BaseUser { get; set; }
        public Company? Company {get;set;}
    }
}