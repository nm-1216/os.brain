using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Os.Brain.Models;
using Os.Brain.ViewModels.SystemApp;
using System.Linq;

namespace Os.Brain.Controllers
{
    [Area("SystemApp")]
    public class UsersController : App_ModulesController<UsersController>
    {


        #region List
        // GET: Users
        public IActionResult Index()
        {
            _initInFo(string.Empty, "用户信息管理", string.Empty, "用户信息列表");
            return View(_userManager.Users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return HttpNotFound();
            }

            UserCreateViewModel model = new UserCreateViewModel();
            model.User = await _userManager.FindByIdAsync(id);

            if (null == model.User)
            {
                return HttpNotFound();
            }

            var temp = await _userManager.GetRolesAsync(model.User);

            model.Password = "helloworld123";
            model.Email = model.User.Email;
            model.RoleList = _roleManager.Roles.Where(n => !temp.Select(x => x).Contains(n.Name)).ToList();
            model.RoleSelectList = _roleManager.Roles.Where(n => temp.Select(x => x).Contains(n.Name)).ToList();

            _initInFo(string.Empty, "用户信息管理", string.Empty, "用户详细信息");

            return View(model);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            _initInFo(string.Empty, "用户信息管理", string.Empty, "创建新用户", "账户信息");
            UserCreateViewModel model = new UserCreateViewModel();
            model.RoleList = _roleManager.Roles;
            model.RoleSelectList = new List<Role>();
            model.User = new User();
            model.User.HireDate = model.User.ResignationDate = DateTime.Now;

            return View(model);
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.User.Email = model.User.UserName = model.Email;
                var result = await _userManager.CreateAsync(model.User, model.Password);
                var result1= await _userManager.AddToRolesAsync(model.User, model.RoleSelectListValue);

                if (result.Succeeded)
                {
                    if (result1.Succeeded)
                    {
                        _logger.LogInformation(3, "User created a new account with password.");
                        return RedirectToAction("Index");
                    }

                    AddErrors(result1);
                }

                AddErrors(result);
            }

            return View(model);
        }
        #endregion

        #region Edit
        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return HttpNotFound();
            }

            UserCreateViewModel model = new UserCreateViewModel();
            model.User = await _userManager.FindByIdAsync(id);            

            if (null == model.User)
            {
                return HttpNotFound();
            }

            var temp = await _userManager.GetRolesAsync(model.User);

            model.Password = "helloworld123";
            model.Email = model.User.Email;
            model.RoleList = _roleManager.Roles.Where(n => !temp.Select(x => x).Contains(n.Name)).ToList();
            model.RoleSelectList = _roleManager.Roles.Where(n => temp.Select(x => x).Contains(n.Name)).ToList();

            _initInFo(string.Empty, "用户信息管理", string.Empty, "用户信息管理", "账户信息");

            return View(model);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.User.Id);

                user.Cname = model.User.Cname;
                user.Description = model.User.Description;
                user.DOB = model.User.DOB;
                user.Email = model.User.Email;
                user.Ename = model.User.Ename;
                user.Ext = model.User.Ext;
                user.Group = model.User.Group;
                user.HireDate = model.User.HireDate;
                user.IDCard = model.User.IDCard;
                user.LockIp = model.User.LockIp;
                user.Mobile = model.User.Mobile;
                user.NO = model.User.NO;
                user.Photo = model.User.Photo;
                user.ProfessionalTitle = model.User.ProfessionalTitle;
                user.ResignationDate = model.User.ResignationDate;
                user.Sex = model.User.Sex;
                user.Tel = model.User.Tel;
                user.UserType = model.User.UserType;

                var flag = false;

                var result = await _userManager.UpdateAsync(user);

                var result1 = await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));

                if (model.RoleSelectListValue!=null&&model.RoleSelectListValue.Count()>0)
                {
                    var result2 = await _userManager.AddToRolesAsync(user, model.RoleSelectListValue);
                    if (!result2.Succeeded)
                    {
                        flag = true;
                        AddErrors(result2);
                    }
                }


                if ("helloworld123" != model.Password)
                {
                   var temp= await _userManager.RemovePasswordAsync(user);

                    var result3 = await _userManager.AddPasswordAsync(user, model.Password);
                    if (!result3.Succeeded)
                    {
                        flag = true;
                        AddErrors(result3);
                    }
                }

                if (!result.Succeeded)
                {
                    flag = true;
                    AddErrors(result);
                }
                if (!result1.Succeeded)
                {
                    flag = true;
                    AddErrors(result1);
                }

                if (!flag)
                {
                    _logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToAction("Index");
                }
            }

            _initInFo(string.Empty, "用户信息管理", string.Empty, "编辑用户信息", "账户信息");
            model.RoleList = _roleManager.Roles;
            model.RoleSelectList = new List<Role>();

            return View(model);

        }
        #endregion

        #region delete
        // GET: Users/Delete/5
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return HttpNotFound();
            }

            User user = await _userManager.FindByIdAsync(id);

            if (null == user)
            {
                return HttpNotFound();
            }

            _initInFo(string.Empty, "用户信息管理", string.Empty, "删除用户信息");

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            _initInFo(string.Empty, "用户信息管理", string.Empty, "确认删除用户信息");

            User user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
