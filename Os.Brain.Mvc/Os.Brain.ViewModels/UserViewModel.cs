

namespace Os.Brain.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Os.Brain.Models;

    public class UserViewModel
    {

        public User User { get; set; }

        [Display(Name = "用户角色")]
        public IEnumerable<Role> RoleList { get; set; }
        public IEnumerable<string> RoleListValue { get; set; }

        [Display(Name = "用户角色")]
        public IEnumerable<Role> RoleSelectList { get; set; }
        public IEnumerable<string> RoleSelectListValue { get; set; }

    }
}
