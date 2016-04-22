using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Os.Brain.Models;

namespace Os.Brain.ViewModels.SystemApp
{
    public class UserCreateViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public User User { get; set; }
        [Display(Name = "用户角色")]
        public IEnumerable<Role> RoleList { get; set; }
        public IEnumerable<string> RoleListValue { get; set; }

        [Display(Name = "用户角色")]
        public IEnumerable<Role> RoleSelectList { get; set; }
        public IEnumerable<string> RoleSelectListValue { get; set; }
    }
}
