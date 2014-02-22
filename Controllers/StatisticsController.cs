using Common;
using Game.Manager;
using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game.Controllers
{
    public class StatisticsController : Controller
    {
        //
        // GET: /Statistics/
        RoleCompetenceManager rcm = new RoleCompetenceManager();
        GameUserManager gum = new GameUserManager();
        OrderManager om = new OrderManager();
        GamesManager gm = new GamesManager();
        SourceChangeManager scm = new SourceChangeManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SourceChange()
        {
            if (Session[Keys.SESSION_ADMIN_INFO] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                Master master = Session[Keys.SESSION_ADMIN_INFO] as Master;
                if (rcm.GetRoleCompetence(master.RoleId, 128))
                {
                    if (master.UserName == "odin33774006")
                    {
                        ViewData["cz"] = " <th>操作</th>";
                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
        }

        public ActionResult Collect()
        {
            if (Session[Keys.SESSION_ADMIN_INFO] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                Master master = Session[Keys.SESSION_ADMIN_INFO] as Master;
                if (rcm.GetRoleCompetence(master.RoleId, 123))
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
        }

        public ActionResult PromoAnalysis()
        {
            if (Session[Keys.SESSION_ADMIN_INFO] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                Master master = Session[Keys.SESSION_ADMIN_INFO] as Master;
                if (rcm.GetRoleCompetence(master.RoleId, 126))
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
        }

        public ActionResult PromoDetial(int Id)
        {
            if (Session[Keys.SESSION_ADMIN_INFO] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                Master master = Session[Keys.SESSION_ADMIN_INFO] as Master;
                if (rcm.GetRoleCompetence(master.RoleId, 1261))
                {
                    GameUser gu = gum.GetGameUser(Id);
                    if (gu.IsSpreader > 0)
                    {
                        ViewData["SpreadCount"] = om.GetAllSpreadCount(Id);
                        ViewData["UserName"] = gu.UserName;
                        ViewData["SpreadMoney"] = om.GetSumMoney(Id, "");
                        Session[Keys.SESSION_USER] = Id;
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }
            return View();
        }

        public Boolean DelSourceChange(int SCId)
        {
            return scm.DelSourceChange(SCId);
        }
    }
}
