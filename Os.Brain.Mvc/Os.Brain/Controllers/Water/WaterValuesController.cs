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
    public class WaterValuesController : App_ModulesController<ApplicationsController>
    {

        public readonly UploadFiles _UploadFiles;
        public WaterValuesController(IOptions<UploadFiles> upfile)
        {
            _UploadFiles = upfile.Value;
        }
        // GET: WaterValues
        public async Task<IActionResult> Index(string id, int? year, Month? month, int page = 1)
        {
            _initInFo(string.Empty, "自来水抄表管理", string.Empty, "抄表信息列表");

            var user = await GetCurrentUserAsync();

            var list = new PageList<WaterValue>(_context.WaterValue.OrderBy(o => o.Wm_IdCard).Where(n =>

            (string.IsNullOrEmpty(id) || n.Wm_IdCard.Contains(id.Trim()))
            && (null == year || n.Wv_Year == year)
            && (null == month || n.Wv_Month == month)

            ), page, user.PageSize);

            return View(list);
        }

        // GET: WaterValues/Details/5
        public IActionResult Details(string id, int year, Month month)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterValue waterValue = _context.WaterValue.Single(m => m.Wm_IdCard == id && m.Wv_Year == year && m.Wv_Month == month);
            if (waterValue == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "自来水抄表管理", string.Empty, "查看抄表信息列表");

            return View(waterValue);
        }

        // GET: WaterValues/Create
        public IActionResult Create()
        {
            _initInFo(string.Empty, "自来水抄表管理", string.Empty, "导入抄表信息列表");

            return View();
        }

        // POST: WaterUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IList<IFormFile> files)
        {
            _initInFo(string.Empty, "自来水抄表管理", string.Empty, "导入抄表信息列表");
            var user = await GetCurrentUserAsync();

            if (files.Count <= 0)
            {
                ModelState.AddModelError(string.Empty, "请选择Excel文档");
                return View();
            }

            await _context.Database.ExecuteSqlCommandAsync("truncate table WaterValueImports");

            #region foreach
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
                        sheet = wk.GetSheet("抄表");
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
                        ModelState.AddModelError(string.Empty, "Excel文档没有【抄表】工作簿");
                        return View();
                    }
                    if (sheet.LastRowNum < 2)
                    {
                        ModelState.AddModelError(string.Empty, "抄表工作簿没数据");
                        return View();
                    }

                    if (
                           sheet.GetRow(1).GetCell(0).ToString().Trim() != "户号"
                        || sheet.GetRow(1).GetCell(1).ToString().Trim() != "社区"
                        || sheet.GetRow(1).GetCell(2).ToString().Trim() != "姓名"
                        || sheet.GetRow(1).GetCell(3).ToString().Trim() != "本月读数"
                        || sheet.GetRow(1).GetCell(4).ToString().Trim() != "上月读数"
                        || sheet.GetRow(0).GetCell(0).ToString().Trim() != "年"
                        || sheet.GetRow(0).GetCell(2).ToString().Trim() != "月"
                    )
                    {
                        ModelState.AddModelError(string.Empty, "抄表工作簿列不正确【列名或排序】");
                        return View();
                    }

                    var Wv_Year =int.Parse(sheet.GetRow(0).GetCell(1).ToString().Trim());
                    Month Wv_Month = (Month)(int.Parse(sheet.GetRow(0).GetCell(3).ToString().Trim()));
                    var Wv_ReadTime = DateTime.Now;
                    var Wv_AddUser = user.Cname;

                    #region for
                    for (int j = 2; j <= sheet.LastRowNum; j++)
                    {
                        var Wm_IdCard = sheet.GetRow(j).GetCell(0);
                        var Wv_Start = sheet.GetRow(j).GetCell(4);
                        var Wv_End = sheet.GetRow(j).GetCell(3);

                        if (null != Wv_Start)
                            Wv_Start.SetCellType(CellType.String);
                        if (null != Wv_End)
                            Wv_End.SetCellType(CellType.String);

                        int? Wv_Start_value=null;

                        if (null != Wv_Start && !string.IsNullOrEmpty(Wv_Start.StringCellValue.Trim()))
                        {
                            
                            Wv_Start_value = int.Parse(Wv_Start.StringCellValue.Trim());
                        }

                        if (
                            null != Wm_IdCard
                            && null != Wv_End
                            && !string.IsNullOrEmpty(Wm_IdCard.ToString().Trim())
                            && !string.IsNullOrEmpty(Wv_End.ToString().Trim())
                          )
                        {
                            _context.WaterValueImport.Add(new WaterValueImport()
                            {
                                Wm_IdCard = Wm_IdCard.ToString().Trim(),
                                Wv_Start = Wv_Start_value,
                                Wv_End = int.Parse(Wv_End.ToString().Trim()),
                                Wv_AddTime = Wv_ReadTime,
                                Wv_AddUser = Wv_AddUser,
                                Wv_Year = Wv_Year,
                                Wv_Month = Wv_Month,
                                Wv_ReadTime = Wv_ReadTime,
                                Wv_DoTime = Wv_ReadTime,
                                Wv_OldStart = 0,
                                Wv_OldEnd = 0,
                                Wv_Price = 0,
                                Wv_Prints = 0,
                                Wv_Status = 0,
                                Wv_ExChange = 0
                            });
                        }
                    }
                    #endregion
                }
            }
            #endregion

            await _context.SaveChangesAsync();

            await _context.Database.ExecuteSqlCommandAsync("ImportWaterValues");

            ModelState.AddModelError(string.Empty, "上传成功");
            return View();
        }


        // GET: WaterValues/Edit/5
        public IActionResult Edit(string id, int year, Month month)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterValue waterValue = _context.WaterValue.Single(m => m.Wm_IdCard == id && m.Wv_Year == year && m.Wv_Month == month);
            if (waterValue == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "自来水抄表管理", string.Empty, "修改抄表信息列表");

            return View(waterValue);
        }

        // POST: WaterValues/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WaterValue waterValue)
        {
            if (ModelState.IsValid)
            {
                WaterValue _waterValue = _context.WaterValue.Single(m => m.Wm_IdCard == waterValue.Wm_IdCard && m.Wv_Year == waterValue.Wv_Year && m.Wv_Month == waterValue.Wv_Month);

                _waterValue.Wv_Start = waterValue.Wv_Start;
                _waterValue.Wv_End = waterValue.Wv_End;
                _waterValue.Wv_Status = waterValue.Wv_Status;
                _waterValue.Wv_ExChange = waterValue.Wv_ExChange;

                _context.Update(_waterValue);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waterValue);
        }

        // GET: WaterValues/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(string id, int year, Month month)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            WaterValue waterValue = _context.WaterValue.Single(m => m.Wm_IdCard == id && m.Wv_Year == year && m.Wv_Month == month);
            if (waterValue == null)
            {
                return HttpNotFound();
            }
            _initInFo(string.Empty, "自来水抄表管理", string.Empty, "删除抄表信息列表");

            return View(waterValue);
        }

        // POST: WaterValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id, int year, Month month)
        {
            WaterValue waterValue = _context.WaterValue.Single(m => m.Wm_IdCard == id && m.Wv_Year == year && m.Wv_Month == month);
            _context.WaterValue.Remove(waterValue);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
