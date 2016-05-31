using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Os.Brain.Models;

namespace Os.Brain.Controllers
{
    [Area("water")]
    public class PricesTypesController : App_ModulesController<ApplicationsController>
    {
        // GET: PricesTypes
        public IActionResult Index()
        {
            _initInFo(string.Empty, "自来水用户管理", string.Empty, "价格信息列表");

            return View(_context.PricesType.ToList());
        }

        // GET: PricesTypes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            PricesType pricesType = _context.PricesType.Single(m => m.ids == id);
            if (pricesType == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "自来水用户管理", string.Empty, "查看价格信息");

            return View(pricesType);
        }

        // GET: PricesTypes/Create
        public IActionResult Create()
        {
            _initInFo(string.Empty, "自来水用户管理", string.Empty, "添加价格信息");

            return View();
        }

        // POST: PricesTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PricesType pricesType)
        {
            if (ModelState.IsValid)
            {
                pricesType.addTime = DateTime.Now;
                _context.PricesType.Add(pricesType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pricesType);
        }

        // GET: PricesTypes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            PricesType pricesType = _context.PricesType.Single(m => m.ids == id);
            if (pricesType == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "自来水用户管理", string.Empty, "修改价格信息");

            return View(pricesType);
        }

        // POST: PricesTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PricesType pricesType)
        {
            if (ModelState.IsValid)
            {
                pricesType.addTime = DateTime.Now;

                _context.Update(pricesType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pricesType);
        }

        // GET: PricesTypes/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            PricesType pricesType = _context.PricesType.Single(m => m.ids == id);
            if (pricesType == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "自来水用户管理", string.Empty, "删除价格信息");

            return View(pricesType);
        }

        // POST: PricesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            PricesType pricesType = _context.PricesType.Single(m => m.ids == id);
            _context.PricesType.Remove(pricesType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
