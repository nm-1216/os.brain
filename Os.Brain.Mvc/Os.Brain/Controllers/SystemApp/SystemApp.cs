namespace Os.Brain.Controllers
{
    using Microsoft.AspNet.Mvc;
    using Models;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    [Area("SystemApp")]
    public class AppManager : App_ModulesController<AppManager>
    {


        [HttpGet]
        public IActionResult Index()
        {
            _initInFo(string.Empty, "应用列表管理", string.Empty, "应用列表");
            return View(_context.Applications.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            _initInFo(string.Empty, "应用列表管理", string.Empty, "增加应用");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Application model)
        {
            _initInFo(string.Empty, "应用列表管理", string.Empty, "增加应用");
            _context.Applications.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");

        }
    }
}
