using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Os.Brain.Models;
using System.Collections.Generic;
using Os.Brain.ViewModels.Water;
using Os.Brain.Mvc.Pager;
using System.Threading.Tasks;

namespace Os.Brain.Controllers
{
    [Area("water")]
    public class WaterPaymentsController : App_ModulesController<ApplicationsController>
    {
        // GET: WaterPayments
        public IActionResult Index()
        {
            _initInFo(string.Empty, "单月结账管理", string.Empty, "结账信息");

            var tmp1 = from tab in _context.WaterValue select new { year = tab.Wv_Year, month = tab.Wv_Month };
            var tmp2 = from tab in _context.WaterPayment select new { year = tab.Wv_Year, month = tab.Wv_Month };

            var list1 = tmp1.ToList().Distinct();
            var list2 = tmp2.ToList().Distinct();
            var reslut = from a in list1
                         join i in list2 on new { a.year, a.month } equals new { i.year, i.month } into c
                         from o in c.DefaultIfEmpty()
                         select new WaterPaymentsViewModel { Year = a.year, Month = a.month, IsExist = o == null ? false : true };

            return View(reslut.ToList());
        }

        [HttpGet]
        public IActionResult Details(string id, int year, Month month)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterPayment waterPayment = _context.WaterPayment.Include(t => t.WaterValue).Include(t => t.WaterValue.WaterMeter).Single(m => m.Wm_IdCard == id && m.Wv_Year == year && m.Wv_Month == month);
            if (waterPayment == null)
            {
                return HttpNotFound();
            }

            return View(waterPayment);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsConfirmed(string id, int year, Month month)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterPayment waterPayment = _context.WaterPayment.Include(t => t.WaterValue).Include(t => t.WaterValue.WaterMeter).Single(m => m.Wm_IdCard == id && m.Wv_Year == year && m.Wv_Month == month && m.IsPay == false);
            if (waterPayment == null)
            {
                return HttpNotFound();
            }
            waterPayment.IsPay = true;
            _context.Update(waterPayment);
            _context.SaveChanges();
            return View(waterPayment);

        }

        // GET: WaterPayments/Create
        public IActionResult Create()
        {
            ViewData["PricesType_ids"] = new SelectList(_context.PricesType, "ids", "PricesType");
            ViewData["Wm_IdCard"] = new SelectList(_context.WaterValue, "Wm_IdCard", "WaterValue");
            return View();
        }

        // POST: WaterPayments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WaterPayment waterPayment)
        {
            if (ModelState.IsValid)
            {
                _context.WaterPayment.Add(waterPayment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["PricesType_ids"] = new SelectList(_context.PricesType, "ids", "PricesType", waterPayment.PricesType_ids);
            ViewData["Wm_IdCard"] = new SelectList(_context.WaterValue, "Wm_IdCard", "WaterValue", waterPayment.Wm_IdCard);
            return View(waterPayment);
        }

        // GET: WaterPayments/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterPayment waterPayment = _context.WaterPayment.Single(m => m.Wm_IdCard == id);
            if (waterPayment == null)
            {
                return HttpNotFound();
            }
            ViewData["PricesType_ids"] = new SelectList(_context.PricesType, "ids", "PricesType", waterPayment.PricesType_ids);
            ViewData["Wm_IdCard"] = new SelectList(_context.WaterValue, "Wm_IdCard", "WaterValue", waterPayment.Wm_IdCard);
            return View(waterPayment);
        }

        // POST: WaterPayments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WaterPayment waterPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Update(waterPayment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["PricesType_ids"] = new SelectList(_context.PricesType, "ids", "PricesType", waterPayment.PricesType_ids);
            ViewData["Wm_IdCard"] = new SelectList(_context.WaterValue, "Wm_IdCard", "WaterValue", waterPayment.Wm_IdCard);
            return View(waterPayment);
        }

        // GET: WaterPayments/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? year, Month? month)
        {
            if (year == null && month == null)
            {
                return HttpNotFound();
            }

            var tmp1 = from tab in _context.WaterValue select new { year = tab.Wv_Year, month = tab.Wv_Month };
            var tmp2 = from tab in _context.WaterPayment select new { year = tab.Wv_Year, month = tab.Wv_Month };

            var list1 = tmp1.Where(n => n.year == year && n.month == month).ToList().Distinct();
            var list2 = tmp2.Where(n => n.year == year && n.month == month).ToList().Distinct();

            if (list1.Count() == 1 && list2.Count() == 0)
            {
                _initInFo(string.Empty, "单月结账管理", string.Empty, "单月结账");

                return View(new WaterPaymentsViewModel() { Year = year.Value, Month = month.Value, IsExist = false });
            }
            else
            {
                return HttpNotFound();
            }


        }

        // POST: WaterPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(WaterPaymentsViewModel model)
        {
            string sql = string.Format("exec jiesuan @year={0},@month={1}", model.Year, (int)model.Month);
            _context.Database.ExecuteSqlCommand(sql);
            return RedirectToAction("Index");
        }

        #region 收费
        public async Task<IActionResult> Pay(string id, int? year, Month? month, string uname, bool? isPay, int page = 1)
        {
            _initInFo(string.Empty, "单月结账管理", string.Empty, "收费缴费");

            var user = await GetCurrentUserAsync();
            var list = new PageList<WaterPayment>(
            _context.WaterPayment.Include(t => t.WaterValue).Include(t => t.WaterValue.WaterMeter)
            .Where(n =>
            (
               string.IsNullOrEmpty(id) || n.Wm_IdCard.Contains(id))
            //&& (string.IsNullOrEmpty(uname) || n.WaterValue.WaterMeter.Wu_Name.Contains(uname))
            && (!isPay.HasValue || n.IsPay == isPay)
            && (!month.HasValue || n.Wv_Month == month)
            && (!year.HasValue || n.Wv_Year == year)
            )

            , page, user.PageSize);

            return View(list);
        }

        #endregion

    }
}
