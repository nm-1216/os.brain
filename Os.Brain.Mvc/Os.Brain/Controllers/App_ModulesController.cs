

namespace Os.Brain.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Hosting;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;

    public class App_ModulesController<T> : Controller
    {
        //public readonly UserManager<User> _userManager;

        [FromServices]
        public ApplicationDbContext _context { get; set; }

        [FromServices]
        public ILogger<T> _logger { get; set; }

        [FromServices]
        public IHostingEnvironment _env { get; set; }

        [FromServices]
        public UserManager<User> _userManager { get; set; }

        [FromServices]
        public RoleManager<Role> _roleManager { get; set; }



        public App_ModulesController()
        {
        }

        private string help = string.Empty;
        private string ico = string.Empty;

        /// <summary>
        /// 图标
        /// </summary>
        public string ICO
        {
            get { if (string.IsNullOrEmpty(this.ico)) return "/Images/Fw/Ico/sys-com.gif"; return ico; }
            set { this.ico = value; }
        }

        /// <summary>
        /// 主题
        /// </summary>
        public string TITLE { get; set; }

        /// <summary>
        /// 帮助
        /// </summary>
        public string HELP
        {
            get { if (string.IsNullOrEmpty(this.help)) return "帮助"; return help; }
            set { this.help = value; }
        }

        /// <summary>
        /// 当前操作
        /// </summary>
        public string DO { get; set; }

        public string SubTitle { get; set; }

        /// <summary>
        /// 功能按钮
        /// </summary>
        public string BTN { get; set; }


        public void _initInFo(string ico, string title, string help, string Do)
        {
            _initInFo(ico, title, help, Do, title);
        }

        public void _initInFo(string ico, string title, string help, string Do, string subtitle)
        {
            this.ico = ico;
            this.TITLE = title;
            this.help = help;
            this.DO = Do;
            this.SubTitle = subtitle;

            ViewBag.ICO = this.ICO;
            ViewBag.HELP = this.HELP;
            ViewBag.Title = this.TITLE; //"系统框架信息";
            ViewBag.DO = this.DO;//"查看信息";
            ViewBag.SubTitle = this.SubTitle;//"查看信息";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            base.Dispose(disposing);
        }

        #region help
        public async Task<User> GetCurrentUserAsync()
        {
            return await _userManager.FindByIdAsync(HttpContext.User.GetUserId());
        }

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        #endregion

    }
}
