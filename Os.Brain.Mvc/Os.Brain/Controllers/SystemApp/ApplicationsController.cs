using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using Os.Brain.Models;
using Os.Brain.Mvc.Pager;
using Os.Brain.ViewModels.SystemApp;

namespace Os.Brain.Controllers
{
    [Area("SystemApp")]
    public class ApplicationsController : App_ModulesController<ApplicationsController>
    {

        // GET: Applications
        public async Task<IActionResult> Index(int page=1)
        {
            _initInFo(string.Empty, "应用列表管理", string.Empty, "应用列表");

            var user = await GetCurrentUserAsync();

            var list = new PageList<Os.Brain.Models.Application>(_context.Application.OrderBy(o=>o.OrderBy), page, user.PageSize);
            
            return View(list);
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "应用列表管理", string.Empty, "应用详细信息");

            Application application = await _context.Application.SingleAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return HttpNotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            _initInFo(string.Empty, "应用列表管理", string.Empty, "增加应用");

            return View();
        }

        // POST: Applications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Application application)
        {
            if (ModelState.IsValid)
            {
                _context.Application.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "应用列表管理", string.Empty, "应用信息修改");

            Application application = await _context.Application.SingleAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Application application)
        {
            if (ModelState.IsValid)
            {
                _context.Update(application);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        // GET: Applications/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "应用列表管理", string.Empty, "删除应用");

            Application application = await _context.Application.SingleAsync(m => m.ApplicationId == id);
            if (application == null)
            {
                return HttpNotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Application application = await _context.Application.SingleAsync(m => m.ApplicationId == id);
            _context.Application.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Order()
        {
            _initInFo(string.Empty, "应用列表管理", string.Empty, "增加应用");

            var list = await _context.Application.OrderBy(m=>m.OrderBy).ToListAsync();

            IList<SelectListItem> model = new List<SelectListItem>();

            string lv = string.Empty; 

            foreach (var i in list)
            {
                SelectListItem item = new SelectListItem();
                item.Text = i.ApplicationName;
                item.Value = i.ApplicationId;
                model.Add(item);
                lv += ("," + item.Value);

            }

            ViewBag.SelectListItem = model;
            ViewBag.ListValue = lv.Trim(',',' ');

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(string list)
        {
            if (list == null)
            {
                return HttpNotFound();
            }
            var vList = list.Trim(',',' ').Split(',');

            var aList = await _context.Application.ToListAsync();

            for (int i = 0; i < vList.Length; i++)
            {
                var model = aList.Single(m => m.ApplicationId == vList[i]);
                if (null != model)
                {
                    model.OrderBy = i + 1;
                    _context.Update(model);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



    }
}
