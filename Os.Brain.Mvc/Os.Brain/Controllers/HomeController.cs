using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Os.Brain.Models;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;
using Microsoft.AspNet.Identity;

namespace Os.Brain.Controllers
{
    [Area("admin")]
    [Authorize]
    public class HomeController : App_ModulesController<HomeController>
    {
        public IActionResult Index()
        {
            var menu = GetMenus();
            ViewData["menu"] = menu;

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            
            Response.StatusCode = 500;
            
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
                
                // This error would not normally be exposed to the client
                //await context.Response.WriteAsync("<br>Error: " + HtmlEncoder.Default.Encode(error.Error.Message) + "<br>\r\n");
            }

            return View();
        }


        public IActionResult Desk()
        {
            _initInFo(string.Empty, "系统框架信息", string.Empty, "查看信息");
            return View();
        }

        #region Help

        public string[] GetMenus()
        {
            string t1 = "<li data-val=\"#tabs-{0}\" class=\"on\">{1}</li>";
            string t2 = "<li class=\"lines\"></li><li data-val=\"#tabs-{0}\">{1}</li>";


            string t3 = "\r\n<div id=\"tabs-{0}\"><ul class=\"tab_con clearfix\"><li class=\"li_left\"></li>\r\n{1}<li class=\"li_right\"></li></ul></div>";
            string t6 = "\r\n<div id=\"tabs-{0}\" class=\"collapse\"><ul class=\"tab_con clearfix\"><li class=\"li_left\"></li>\r\n{1}<li class=\"li_right\"></li></ul></div>";

            string t4 = "<li class=\"data_val\" data-val=\"{0}\">{1}</li>\r\n";
            string t5 = "<li class=\"li_line\"></li><li class=\"data_val\" data-val=\"{0}\">{1}</li>\r\n";

            IQueryable<Path> list = null;

            string temp = string.Empty;

            string temp1 = string.Empty;

            string temp2 = string.Empty;

            
            
            
            {
                list = _context.Path.Where(m => m.ParentId == null).OrderBy(m => m.PathCategory);

                int j = 0;

                int n = 0;

                foreach (Path ii in list)
                {
                    if (j == 0)
                    {
                        temp += string.Format(t1, ii.PathId, ii.PathName);
                    }
                    else
                    {
                        temp += string.Format(t2, ii.PathId, ii.PathName);
                    }

                    IQueryable<Path> xx = null;

                   
                    {
                        xx = _context.Path.Where(o => o.ParentId == ii.PathId).OrderBy(m => m.PathCategory);


                        n = 0;
                        temp1 = string.Empty;
                        foreach (var jj in xx)
                        {
                            if (n == 0)
                            {
                                temp1 += string.Format(t4, jj._Path, jj.PathName);
                            }
                            else
                            {
                                temp1 += string.Format(t5, jj._Path, jj.PathName);
                            }

                            n++;
                        }
                        if (j == 0)
                            temp2 += string.Format(t3, ii.PathId, temp1);
                        else
                            temp2 += string.Format(t6, ii.PathId, temp1);
                    }

                    j++;
                }
            }

            return new string[] { temp, temp2 };
        }


        #endregion
    }
}
