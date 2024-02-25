using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BeautyBook.DAL.Context;
using Microsoft.AspNetCore.Identity;

namespace BeautyBook.Models
{
    public class BaseUser : IdentityUser
    {
        public string? UserSurname { get; set; } = string.Empty;
        public string? Photo { get; set; } = string.Empty;
        [ForeignKey("WorkerId")]
        public Worker? Worker { get; set; }
        public List<CompanyLike>? FavoriteCompanies { get; set; }


    
    }
}