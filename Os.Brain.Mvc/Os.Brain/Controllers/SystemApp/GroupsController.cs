using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using Os.Brain.Models;

namespace Os.Brain.Controllers
{
    [Area("SystemApp")]

    public class GroupsController : App_ModulesController<GroupsController>
    {


        // GET: Groups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Group.ToListAsync());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Group group = await _context.Group.SingleAsync(m => m.GroupId == id);
            if (group == null)
            {
                return HttpNotFound();
            }

            return View(group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Group group)
        {
            if (ModelState.IsValid)
            {
                _context.Group.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Group group = await _context.Group.SingleAsync(m => m.GroupId == id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Group group)
        {
            if (ModelState.IsValid)
            {
                _context.Update(group);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Group group = await _context.Group.SingleAsync(m => m.GroupId == id);
            if (group == null)
            {
                return HttpNotFound();
            }

            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Group group = await _context.Group.SingleAsync(m => m.GroupId == id);
            _context.Group.Remove(group);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
