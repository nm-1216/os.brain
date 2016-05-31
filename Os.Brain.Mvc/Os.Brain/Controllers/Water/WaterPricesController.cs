using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Os.Brain.Models;

namespace Os.Brain.Controllers
{
    [Area("water")]
    public class WaterPricesController : App_ModulesController<ApplicationsController>
    {
        // GET: WaterPrices
        public IActionResult Index(string ids)
        {
            _initInFo(string.Empty, "水价明细管理", string.Empty, "水价明细列表");

            return View(_context.WaterPrices.Where(u=>(string.IsNullOrEmpty(ids) ||u.ids.ToString()==ids)).ToList());
        }

        // GET: WaterPrices/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterPrices waterPrices = _context.WaterPrices.Single(m => m.Prices_Id == id);
            if (waterPrices == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "水价明细管理", string.Empty, "查看水价明细");

            return View(waterPrices);
        }

        // GET: WaterPrices/Create
        public IActionResult Create()
        {
            _initInFo(string.Empty, "水价明细管理", string.Empty, "添加水价明细");

            return View();
        }

        // POST: WaterPrices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WaterPrices waterPrices)
        {
            if (ModelState.IsValid)
            {
                waterPrices.Prices_AddTime = DateTime.Now;
                _context.WaterPrices.Add(waterPrices);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waterPrices);
        }

        // GET: WaterPrices/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterPrices waterPrices = _context.WaterPrices.Single(m => m.Prices_Id == id);
            if (waterPrices == null)
            {
                return HttpNotFound();
            }

            _initInFo(string.Empty, "水价明细管理", string.Empty, "修改水价明细");

            return View(waterPrices);
        }

        // POST: WaterPrices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WaterPrices waterPrices)
        {
            if (ModelState.IsValid)
            {
                waterPrices.Prices_AddTime = DateTime.Now;

                _context.Update(waterPrices);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waterPrices);
        }

        // GET: WaterPrices/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterPrices waterPrices = _context.WaterPrices.Single(m => m.Prices_Id == id);
            if (waterPrices == null)
            {
                return HttpNotFound();
            }

            _initInFo(string.Empty, "水价明细管理", string.Empty, "删除水价明细");

            return View(waterPrices);
        }

        // POST: WaterPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            WaterPrices waterPrices = _context.WaterPrices.Single(m => m.Prices_Id == id);
            _context.WaterPrices.Remove(waterPrices);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
