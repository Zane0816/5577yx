using Common;
using Game.Manager;
using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Game.Controllers
{
    public class jhwjController : Controller
    {
        //
        // GET: /jhwj/
        CommonGame cg = new CommonGame();
        Games g = new Games();
        GamesManager gm = new GamesManager();
        ServersMananger sm = new ServersMananger();
        HtmlHelper hh = new HtmlHelper();
        NewsManager nm = new NewsManager();
        GameUserManager gum = new GameUserManager();

        public ActionResult Index()
        {
            return Servers();
        }

        public ActionResult Servers()
        {
            return cg.InitServers("jhwj");
        }

        public ActionResult LoginGame(int S)
        {
            return cg.LoginGame("jhwj", S);
        }

        public ActionResult Gift(int G)
        {
            return cg.GameGift(G);
        }

        public string DoGetGift(int G)
        {
            return cg.DoGetGift(G, null);
        }

        public ActionResult Wd()
        {
            return View();
        }

        public ActionResult WdServers()
        {
            int UserId = BBRequest.GetUserId();
            g = gm.GetGame("jhwj");
            if (UserId > 0)
            {
                GameUser gu = new GameUser();
                gu = gum.GetGameUser(UserId);
                ViewData["UserName"] = gu.UserName;
                ViewData["TjqfHref"] = "#";
                ViewData["TjqfName"] = "暂无推荐区服";
                ViewData["LLHref"] = "#";
                ViewData["LLName"] = "暂无记录";
                OnlineLog ol = new OnlineLog();
                ol = new OnlineLogManager().GetLastLogin(UserId, g.Id);
                if (ol != null)
                {
                    GameServer Llqf = sm.GetGameServer(ol.ServerId);
                    ViewData["LLHref"] = "/" + g.GameNo + "/LoginGame?S=" + Llqf.QuFu;
                    ViewData["LLName"] = Llqf.Name;
                }
                if (g.tjqf > 0)
                {
                    GameServer tjqf = sm.GetGameServer(g.tjqf);
                    ViewData["TjqfHref"] = "/" + g.GameNo + "/LoginGame?S=" + tjqf.QuFu;
                    ViewData["TjqfName"] = tjqf.Name;
                }
                List<GameServer> gsList = new List<GameServer>();
                gsList = sm.GetServersByGame(g.Id);
                string ServerHtml = "";
                foreach (GameServer gs in gsList)
                {
                    switch (gs.State)
                    {
                        case 1:
                            ServerHtml += "<a><span class=\"yellow\"></span>" + gs.Name + "</a>";
                            break;
                        case 2:
                            ServerHtml += "<a><span class=\"gray\"></span>" + gs.Name + "</a>";
                            break;
                        case 3:
                            ServerHtml += "<a href=\"" + g.GameNo + "/LoginGame?S=" + gs.QuFu + "\"><span class=\"green\"></span>" + gs.Name + "</a>";
                            break;
                        case 4:
                            ServerHtml += "<a href=\"" + g.GameNo + "/LoginGame?S=" + gs.QuFu + "\"><span class=\"red\"></span>" + gs.Name + "</a>";
                            break;
                        default:
                            break;
                    }
                }
                ViewData["gsHtml"] = ServerHtml;

                return View();
            }
            else
            {
                return RedirectToAction("Wd");
            }
        }
    }
}
