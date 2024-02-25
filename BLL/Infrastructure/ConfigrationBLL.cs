using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyBook.DAL.Context;
using BeautyBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeautyBook.BLL.Infrastructure
{
    public static class ConfigrationBLL
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            //Database Configuration

            services.AddDbContext<MyDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("myConn"));
            });

            //Identity Configuration
            services.AddIdentity<BaseUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.AllowedUserNameCharacters += " ";

            }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<MyDbContext>()
            .AddDefaultTokenProviders();
            // .AddInvitationToCompanyTokenProvider();
        }


    }
}