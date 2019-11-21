using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AjaxTest.Models
{
    public class SearchUsersMain
    {

        [Display(Name = "Email")]
        [StringLength(50)]
        public string SrchEmail { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        public string SrchFirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string SrchLastName { get; set; }

        public List<SearchUsersDetails> SrchUserList { get; set; }

        public SearchUsersMain()
        { SrchUserList = new List<SearchUsersDetails>(); }

    }

}