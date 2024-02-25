using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyBook.Models
{
    public abstract class BaseClass
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public BaseClass()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }

    }
}