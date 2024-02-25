using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public class Comment : BaseClass
    {
        public string? Text {get;set;}
        public float Star {get;set;}
    }
}