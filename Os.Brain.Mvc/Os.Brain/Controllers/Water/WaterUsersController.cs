//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Http;
//using Microsoft.AspNet.Mvc;
//using Microsoft.Net.Http.Headers;
//using NPOI.HSSF.UserModel;
//using NPOI.SS.UserModel;
//using Os.Brain.Core;
//using Os.Brain.Models;
//using Os.Brain.Mvc.Pager;

//namespace Os.Brain.Controllers
//{
//    [Area("Water")]

//    public class WaterUsersController : App_ModulesController<ApplicationsController>
//    {

//        // GET: WaterUsers
//        public async Task<IActionResult> Index(string Cname, string Village, int page = 1)
//        {
//            _initInFo(string.Empty, "自来水用户管理", string.Empty, "用户信息列表");

//            var user = await GetCurrentUserAsync();

//            var list = new PageList<WaterUser>(_context.WaterUser.OrderBy(o => o.Wu_id).Where(n =>

//            (string.IsNullOrEmpty(Cname) || n.Wu_Name.Contains(Cname.Trim())) &&
//            (string.IsNullOrEmpty(Village) || n.Wu_Village.Contains(Village.Trim()))

//            ), page, user.PageSize);

//            return View(list);
//        }

//        // GET: WaterUsers/Details/5
//        public IActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return HttpNotFound();
//            }

//            WaterUser waterUser = _context.WaterUser.Single(m => m.Wu_id == id);
//            if (waterUser == null)
//            {
//                return HttpNotFound();
//            }
//            _initInFo(string.Empty, "自来水用户管理", string.Empty, "查看用户信息");

//            return View(waterUser);
//        }

//        // GET: WaterUsers/Create
//        public IActionResult Create()
//        {
//            _initInFo(string.Empty, "自来水用户管理", string.Empty, "导入用户信息");

//            return View();
//        }

//        // POST: WaterUsers/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(IList<IFormFile> files)
//        {
//            _initInFo(string.Empty, "自来水用户管理", string.Empty, "导入用户信息");

//            if (files.Count <= 0)
//            {
//                ModelState.AddModelError(string.Empty, "请选择Excel文档");
//                return View();
//            }
//            foreach (var file in files)
//            {
//                if (ContentType.Excel.Contains(file.ContentType))
//                {
//                    var filePath = _env.WebRootPath + "\\" + Guid.NewGuid().ToString();
//                    await file.SaveAsAsync(filePath);

//                    ISheet sheet;
//                    FileStream fs = null;

//                    try
//                    {
//                        fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
//                        HSSFWorkbook wk = new HSSFWorkbook(fs);
//                        sheet = wk.GetSheet("用户");
//                    }
//                    catch (Exception ex)
//                    {
//                        ModelState.AddModelError(string.Empty, ex.Message);
//                        return View();

//                    }
//                    finally
//                    {
//                        fs.Close();
//                        fs.Dispose();
//                    }

//                    if (null == sheet)
//                    {
//                        ModelState.AddModelError(string.Empty, "Excel文档没有【用户】工作簿");
//                        return View();
//                    }
//                    if (sheet.LastRowNum < 1)
//                    {
//                        ModelState.AddModelError(string.Empty, "用户工作簿没数据");
//                        return View();
//                    }

//                    if (
//                        sheet.GetRow(0).GetCell(0).ToString().Trim() != "村庄"
//                        || sheet.GetRow(0).GetCell(1).ToString().Trim() != "用户"
//                        || sheet.GetRow(0).GetCell(2).ToString().Trim() != "电话"
//                        || sheet.GetRow(0).GetCell(3).ToString().Trim() != "地址"
//                    )
//                    {
//                        ModelState.AddModelError(string.Empty, "用户工作簿列不正确【列名或排序】");
//                        return View();
//                    }


//                    for (int j = 1; j < sheet.LastRowNum; j++)
//                    {
//                        var Wu_Village = sheet.GetRow(j).GetCell(0);
//                        var Wu_Name = sheet.GetRow(j).GetCell(1);
//                        var Wu_Tel = sheet.GetRow(j).GetCell(2);
//                        var Wu_Address = sheet.GetRow(j).GetCell(3);

//                        if (null != Wu_Village)
//                            Wu_Village.SetCellType(CellType.String);
//                        if (null != Wu_Name)
//                            Wu_Name.SetCellType(CellType.String);
//                        if (null != Wu_Tel)
//                            Wu_Tel.SetCellType(CellType.String);
//                        if (null != Wu_Address)
//                            Wu_Address.SetCellType(CellType.String);

//                        if (
//                            null != Wu_Village
//                            && null != Wu_Name
//                            //&& null != Wu_Tel
//                            && null != Wu_Address
//                            && !string.IsNullOrEmpty(Wu_Village.StringCellValue.Trim())
//                            && !string.IsNullOrEmpty(Wu_Name.StringCellValue.Trim())
//                            //&& !string.IsNullOrEmpty(Wu_Tel.StringCellValue.Trim())
//                            && !string.IsNullOrEmpty(Wu_Address.StringCellValue.Trim())
//                          )
//                            _context.WaterUser.Add(new WaterUser()
//                            {
//                                Wu_Village = Wu_Village.StringCellValue.Trim().Replace(" ",""),
//                                Wu_Name = Wu_Name.StringCellValue.Trim().Replace(" ", ""),
//                                Wu_Tel = null == Wu_Tel ? string.Empty : Wu_Tel.StringCellValue.Trim().Replace("  "," ").Replace(" ",","),
//                                Wu_Address =Help.ToDBC(Wu_Address.StringCellValue.Trim().Replace(" ", ""))
//                            });
//                    }


//                    await _context.SaveChangesAsync();
//                }
//            }

//            ModelState.AddModelError(string.Empty, "上传成功");
//            return View();
//        }

//        // GET: WaterUsers/Edit/5
//        public IActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return HttpNotFound();
//            }

//            WaterUser waterUser = _context.WaterUser.Single(m => m.Wu_id == id);
//            if (waterUser == null)
//            {
//                return HttpNotFound();
//            }
//            _initInFo(string.Empty, "自来水用户管理", string.Empty, "修改用户信息");

//            return View(waterUser);
//        }

//        // POST: WaterUsers/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(WaterUser waterUser)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Update(waterUser);
//                _context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(waterUser);
//        }

//        // GET: WaterUsers/Delete/5
//        [ActionName("Delete")]
//        public IActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return HttpNotFound();
//            }

//            WaterUser waterUser = _context.WaterUser.Single(m => m.Wu_id == id);
//            if (waterUser == null)
//            {
//                return HttpNotFound();
//            }

//            _initInFo(string.Empty, "自来水用户管理", string.Empty, "删除用户信息");

//            return View(waterUser);
//        }

//        // POST: WaterUsers/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            WaterUser waterUser = _context.WaterUser.Single(m => m.Wu_id == id);
//            _context.WaterUser.Remove(waterUser);
//            _context.SaveChanges();
//            return RedirectToAction("Index");
//        }



//    }
//}
