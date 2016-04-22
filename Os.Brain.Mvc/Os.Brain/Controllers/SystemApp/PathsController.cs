using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using Os.Brain.Models;
using Os.Brain.Mvc.Pager;

namespace Os.Brain.Controllers
{
    [Area("SystemApp")]
    public class PathsController : App_ModulesController<PathsController>
    {


        // GET: Applications
        public async Task<IActionResult> Index(int page = 1)
        {
            _initInFo(string.Empty, "应用列表管理", string.Empty, "应用列表");

            var user = await GetCurrentUserAsync();

            var list = new PageList<Os.Brain.Models.Application>(_context.Application.OrderBy(o => o.OrderBy), page, user.PageSize);

            return View(list);
        }


        // GET: Paths
        public async Task<IActionResult> SubIndex(string ApplicationId,int page=1)
        {
            if (string.IsNullOrEmpty(ApplicationId))
            {
                return HttpNotFound();
            }

            Application application = await _context.Application.SingleAsync(m => m.ApplicationId == ApplicationId);

            if (application == null)
            {
                return HttpNotFound();
            }

            var user = await GetCurrentUserAsync();

            _initInFo(string.Empty, "应用管理", string.Empty, "应用模块管理");

            ViewBag.ApplicationId = ApplicationId;

            ViewBag.SubTitle = "应用管理 ->" + application.ApplicationName;

            var list = new PageList<Os.Brain.Models.Path>(_context.Path.Where(m => m.ApplicationId == ApplicationId && m.ParentId == null), page, user.PageSize);

            return View(list);
        }

        // GET: Paths/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Path path = await _context.Path.SingleAsync(m => m.PathId == id);

            if (path == null)
            {
                return HttpNotFound();
            }

            ViewBag.ApplicationId = path.ApplicationId;

            ViewBag.ParentId = path.PathId;


            Application application = await _context.Application.SingleAsync(m => m.ApplicationId == path.ApplicationId);
            if (string.IsNullOrEmpty(path.ParentId))
            {
                ViewData.Add("PathName", "无");
            }
            else
            {
                Path Parent = await _context.Path.SingleAsync(m => m.PathId == path.ParentId);
                ViewData.Add("PathName", Parent.PathName);
            }

            var child = await _context.Path.OrderBy(m => m.PathCategory).Where(m => m.ParentId == path.PathId).ToListAsync();

            ViewBag.child = child;


            ViewData.Add("ApplicationName", application.ApplicationName);

            _initInFo(string.Empty, "应用模块管理", string.Empty, "基础模组");

            ViewBag.SubTitle = "应用管理 ->" + application.ApplicationName + " -> " + path.PathName;

            return View(path);
        }

        // GET: Paths/Create
        public async Task<IActionResult> Create(string ApplicationId, string ParentId = "")
        {
            _initInFo(string.Empty, "应用模块管理", string.Empty, "基础模组");

            if (string.IsNullOrEmpty(ApplicationId))
            {
                return HttpNotFound();
            }
            Application application = await _context.Application.SingleAsync(m => m.ApplicationId == ApplicationId);

            if (application == null)
            {
                return HttpNotFound();
            }


            ViewData.Add("Application", application);
            if (string.IsNullOrEmpty(ParentId))
            {
                ViewData.Add("Parent", null);
            }
            else
            {
                Path path = await _context.Path.SingleAsync(m => m.PathId == ParentId);
                ViewData.Add("Parent", path);
            }

            return View();
        }

        // POST: Paths/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Path path)
        {
            if (ModelState.IsValid)
            {
                _context.Path.Add(path);
                await _context.SaveChangesAsync();
                if (string.IsNullOrEmpty(path.ParentId))
                    return RedirectToAction("SubIndex", new { ApplicationId = path.ApplicationId });
                else
                    return RedirectToAction("Details", new { id = path.ParentId });
            }
            return View(path);
        }

        // GET: Paths/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Path path = await _context.Path.SingleAsync(m => m.PathId == id);

            if (path == null)
            {
                return HttpNotFound();
            }

            Application application = await _context.Application.SingleAsync(m => m.ApplicationId == path.ApplicationId);
            if (string.IsNullOrEmpty(path.ParentId))
            {
                ViewData.Add("PathName", "无");
            }
            else
            {
                Path Parent = await _context.Path.SingleAsync(m => m.PathId == path.ParentId);
                ViewData.Add("PathName", path.PathName);
            }

            ViewData.Add("ApplicationName", application.ApplicationName);
            _initInFo(string.Empty, "应用模块管理", string.Empty, "基础模组");

            return View(path);
        }

        // POST: Paths/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Path path)
        {
            if (ModelState.IsValid)
            {
                _context.Update(path);
                await _context.SaveChangesAsync();
                if (string.IsNullOrEmpty(path.ParentId))
                    return RedirectToAction("SubIndex", new { ApplicationId = path.ApplicationId });
                else
                    return RedirectToAction("Details", new { id = path.ParentId });
            }
            return View(path);
        }

        // GET: Paths/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Path path = await _context.Path.SingleAsync(m => m.PathId == id);
            if (path == null)
            {
                return HttpNotFound();
            }



            Application application = await _context.Application.SingleAsync(m => m.ApplicationId == path.ApplicationId);
            if (string.IsNullOrEmpty(path.ParentId))
            {
                ViewData.Add("PathName", "无");
            }
            else
            {
                Path Parent = await _context.Path.SingleAsync(m => m.PathId == path.ParentId);
                ViewData.Add("PathName", path.PathName);
            }

            ViewData.Add("ApplicationName", application.ApplicationName);
            _initInFo(string.Empty, "应用模块管理", string.Empty, "基础模组");


            return View(path);
        }

        // POST: Paths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Path path = await _context.Path.SingleAsync(m => m.PathId == id);
            _context.Path.Remove(path);
            await _context.SaveChangesAsync();

            if (string.IsNullOrEmpty(path.ParentId))
                return RedirectToAction("SubIndex", new { ApplicationId = path.ApplicationId });
            else
                return RedirectToAction("Details", new { id = path.ParentId });

        }
    }
}
