using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjaxTest.Models
{
    public class AppUserRoles : IdentityUserRole
    {

        [Display(Name = "User Role ID")]
        [Key]
        public override string UserId { get => base.UserId; set => base.UserId = value; }

        [Display(Name = "User Role ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index(IsUnique = true)]
        public int UserRoleId { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }
    }
}