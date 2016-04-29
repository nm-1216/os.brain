using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Os.Brain.Models.CMS;
using Os.Brain.Mvc.Pager;

namespace Os.Brain.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Area("cms")]
    public class CmsNewsController : App_ModulesController<ApplicationsController>
    {

        public async Task<IActionResult> Index(int page = 1)
        {
            _initInFo(string.Empty, "内容管理", string.Empty, "信息列表");

            var user = await GetCurrentUserAsync();

            var list = new PageList<Cms_News>(_context.Cms_News.OrderBy(o => o.News_AddDate), page, user.PageSize);

            return View(list);
        }

        // GET: Cms_News/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cms_News cms_News = _context.Cms_News.Single(m => m.News_ID == id);
            if (cms_News == null)
            {
                return HttpNotFound();
            }

            return View(cms_News);
        }

        // GET: Cms_News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cms_News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cms_News cms_News)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                cms_News.News_AddUser = cms_News.News_EditUser = user.UserName;
                cms_News.News_AddDate = cms_News.News_EditDate = DateTime.Now;
                cms_News.News_isAuth = 0;

                _context.Cms_News.Add(cms_News);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cms_News);
        }

        // GET: Cms_News/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cms_News cms_News = _context.Cms_News.Single(m => m.News_ID == id);
            if (cms_News == null)
            {
                return HttpNotFound();
            }
            return View(cms_News);
        }

        // POST: Cms_News/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cms_News cms_News)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cms_News);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cms_News);
        }

        // GET: Cms_News/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Cms_News cms_News = _context.Cms_News.Single(m => m.News_ID == id);
            if (cms_News == null)
            {
                return HttpNotFound();
            }

            return View(cms_News);
        }

        // POST: Cms_News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Cms_News cms_News = _context.Cms_News.Single(m => m.News_ID == id);
            _context.Cms_News.Remove(cms_News);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
