using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Extensions.OptionsModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Os.Brain.Core;
using Os.Brain.Models;
using Os.Brain.Mvc.Pager;

namespace Os.Brain.Controllers
{
    [Area("water")]
    public class WaterMetersController : App_ModulesController<ApplicationsController>
    {
        public readonly UploadFiles _UploadFiles;
        public WaterMetersController(IOptions<UploadFiles> upfile)
        {
            _UploadFiles = upfile.Value;
        }

        // GET: WaterMeters
        public async Task<IActionResult> Index(string IdCard, int page = 1)
        {
            _initInFo(string.Empty, "水表管理", string.Empty, "水表信息列表");

            var user = await GetCurrentUserAsync();

            var list = new PageList<WaterMeter>(_context.WaterMeter.OrderBy(o => o.Wm_IdCard).Where(n =>

            (string.IsNullOrEmpty(IdCard) || n.Wm_IdCard.Contains(IdCard.Trim())) 

            ), page, user.PageSize);

            return View(list);
        }

        // GET: WaterMeters/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterMeter waterMeter = _context.WaterMeter.Single(m => m.Wm_IdCard == id);
            if (waterMeter == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "自来水用户管理", string.Empty, "查看水表信息");

            return View(waterMeter);
        }

        // GET: WaterMeters/Create
        public IActionResult Create()
        {
            _initInFo(string.Empty, "自来水用户管理", string.Empty, "导入水表信息");
            return View();
        }

        // POST: WaterMeters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IList<IFormFile> files)
        {
            _initInFo(string.Empty, "自来水用户管理", string.Empty, "导入水表信息");

            if (files.Count <= 0)
            {
                ModelState.AddModelError(string.Empty, "请选择Excel文档");
                return View();
            }


            

            foreach (var file in files)
            {
                if (ContentType.Excel.Contains(file.ContentType))
                {
                    var filePath = _env.WebRootPath + (@"\" + _UploadFiles.xml.Trim('\\') + @"\") + Guid.NewGuid().ToString();
                    await file.SaveAsAsync(filePath);

                    ISheet sheet;
                    FileStream fs = null;

                    try
                    {
                        fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        HSSFWorkbook wk = new HSSFWorkbook(fs);
                        sheet = wk.GetSheet("水表");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View();
                    }
                    finally
                    {
                        fs.Close();
                        fs.Dispose();
                    }

                    if (null == sheet)
                    {
                        ModelState.AddModelError(string.Empty, "Excel文档没有【水表】工作簿");
                        return View();
                    }
                    if (sheet.LastRowNum < 1)
                    {
                        ModelState.AddModelError(string.Empty, "【水表】工作簿没数据");
                        return View();
                    }

                    if (
                        sheet.GetRow(0).GetCell(0).ToString().Trim() != "户号"
                        || sheet.GetRow(0).GetCell(1).ToString().Trim() != "社区"
                        || sheet.GetRow(0).GetCell(2).ToString().Trim() != "姓名"
                        || sheet.GetRow(0).GetCell(3).ToString().Trim() != "电话"
                        || sheet.GetRow(0).GetCell(4).ToString().Trim() != "地址"
                    )
                    {
                        ModelState.AddModelError(string.Empty, "【水表】工作簿列不正确【列名或排序】");
                        return View();
                    }


                    for (int j = 1; j <= sheet.LastRowNum; j++)
                    {
                        var Wm_IdCard = sheet.GetRow(j).GetCell(0);
                        var Wu_Village = sheet.GetRow(j).GetCell(1);
                        var Wu_Name = sheet.GetRow(j).GetCell(2);
                        var Wm_Tel = sheet.GetRow(j).GetCell(3);
                        var Wu_Address = sheet.GetRow(j).GetCell(4);

                        var _isGroup = false;
                        var _isNeedPay = true;

                        if (null != Wm_IdCard && !string.IsNullOrEmpty(Wm_IdCard.ToString().Trim()))
                            _context.WaterMeter.Add(new WaterMeter()
                            {
                                Wm_IdCard = Wm_IdCard.ToString().Trim(),
                                Wm_LogName = Wm_IdCard.ToString().Trim(),
                                Wm_Tel = Wm_Tel.ToString().Trim(),
                                isGroup = _isGroup,
                                isNeedPay = _isNeedPay,
                                Wm_Weixin = string.Empty,
                                Wm_Pwd = string.Empty,
                                Wu_Address = Wu_Address.ToString().Trim(),
                                Wu_Name = Wu_Name.ToString().Trim(),
                                Wu_Village = Wu_Village.ToString().Trim()
                            });
                    }


                    await _context.SaveChangesAsync();
                }
            }

            ModelState.AddModelError(string.Empty, "上传成功");
            return View();
        }

        // GET: WaterMeters/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterMeter waterMeter = _context.WaterMeter.Single(m => m.Wm_IdCard == id);
            if (waterMeter == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "自来水用户管理", string.Empty, "修改水表信息");


            return View(waterMeter);
        }

        // POST: WaterMeters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WaterMeter waterMeter)
        {
            if (ModelState.IsValid)
            {
                WaterMeter _waterMeter = _context.WaterMeter.Single(m => m.Wm_IdCard == waterMeter.Wm_IdCard);

                _waterMeter.Wm_LogName = waterMeter.Wm_LogName;
                _waterMeter.Wm_Tel = waterMeter.Wm_Tel ?? string.Empty;
                _waterMeter.Wm_Weixin = waterMeter.Wm_Weixin ?? string.Empty;
                _waterMeter.isGroup = waterMeter.isGroup;
                _waterMeter.isNeedPay = waterMeter.isNeedPay;

                _context.Update(_waterMeter);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waterMeter);
        }

        // GET: WaterMeters/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterMeter waterMeter = _context.WaterMeter.Single(m => m.Wm_IdCard == id);
            if (waterMeter == null)
            {
                return HttpNotFound();
            }

            _initInFo(string.Empty, "自来水用户管理", string.Empty, "删除水表信息");

            return View(waterMeter);
        }

        // POST: WaterMeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            WaterMeter waterMeter = _context.WaterMeter.Single(m => m.Wm_IdCard == id);
            _context.WaterMeter.Remove(waterMeter);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
