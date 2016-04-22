using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Os.Brain.Models;
using Os.Brain.Mvc.Pager;

namespace Os.Brain.Controllers
{
    public class EventLogsController : App_ModulesController<EventLogsController>
    {
        [Area("SystemApp")]
        public async Task<IActionResult> Index(int page = 1)
        {
            _initInFo(string.Empty, "事件日志管理", string.Empty, "事件日志列表");

            var user = await GetCurrentUserAsync();

            var list = new PageList<Os.Brain.Models.EventLog>(_context.EventLogs.OrderBy(o => o.LogID), page, user.PageSize);

            return View(list);
        }
    }
}
