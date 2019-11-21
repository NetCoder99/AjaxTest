using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AjaxTest.Models
{
    public class SearchUsersDetails
    {
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [Display(Name = "Email Address")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        public SearchUsersDetails() { }
        public SearchUsersDetails(int userId, string email, string firstName, string lastName)
        {
            UserId = userId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public static SearchUsersDetails Converter(AppUser appUser)
        {
            SearchUsersDetails rtn_obj = new SearchUsersDetails();
            rtn_obj.UserId = appUser.UserId;
            rtn_obj.Email = appUser.Email;
            rtn_obj.FirstName = appUser.FirstName;
            rtn_obj.LastName = appUser.LastName;
            return rtn_obj;
        }

    }
}