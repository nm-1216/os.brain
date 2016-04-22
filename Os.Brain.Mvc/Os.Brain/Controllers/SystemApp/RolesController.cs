using System;
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
    public class RolesController : App_ModulesController<RolesController>
    {
        #region list
        // GET: Roles
        public IActionResult Index()
        {
            _initInFo(string.Empty, "角色信息管理", string.Empty, "角色信息列表");

            return View(_roleManager.Roles);
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            Role role = await GetRole(id);
            if (null == role)
            {
                return HttpNotFound();
            }

            _initInFo(string.Empty, "角色信息管理", string.Empty, "角色详细信息");

            return View(role);
        }
        #endregion

        #region Create
        // GET: Roles/Create
        public IActionResult Create()
        {
            _initInFo(string.Empty, "角色信息管理", string.Empty, "创建新角色");

            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
            if (ModelState.IsValid)
            {
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
                await _roleManager.CreateAsync(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
        #endregion

        #region Edit
        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            Role role = await GetRole(id);
            if (null == role)
            {
                return HttpNotFound();
            }

            _initInFo(string.Empty, "角色信息管理", string.Empty, "角色信息列表");

            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
        #endregion

        #region Delete
        // GET: Roles/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            Role role = await GetRole(id);
            if (null == role)
            {
                return HttpNotFound();
            }

            _initInFo(string.Empty, "角色信息管理", string.Empty, "角色信息列表");

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Role role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);

            _logger.LogInformation(3, "");
            return RedirectToAction("Index");
        }
        #endregion

        #region Help
        private async Task<Role> GetRole(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return await _roleManager.FindByIdAsync(id);
        }
        #endregion
    }
}
