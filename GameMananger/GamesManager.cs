﻿using Game.DAL;
using Game.Model;
using System;
using System.Collections.Generic;

namespace Game.Manager
{
    public class GamesManager
    {
        GamesServers gss = new GamesServers();

        /// <summary>
        /// 获取所有游戏
        /// </summary>
        /// <returns>游戏集合</returns>
        public List<Games> GetAll()
        {
            return gss.GetAll();
        }

        /// <summary>
        /// 获取所有游戏
        /// </summary>
        /// <param name="WhereStr">条件</param>
        /// <returns>游戏集合</returns>
        public List<Games> GetAll(string WhereStr)
        {
            return gss.GetAll(WhereStr);
        }

        /// <summary>
        /// 根据游戏Id获取游戏
        /// </summary>
        /// <param name="GameId">游戏Id</param>
        /// <returns>返回游戏信息</returns>
        public Games GetGame(int GameId)
        {
            return gss.GetGame(GameId);
        }

        /// <summary>
        /// 根据订单处理充值
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        /// <returns>返回处理结果</returns>
        public string PayManager(string OrderNo)
        {
            GameUserServers gus = new GameUserServers();
            OrdersServers os = new OrdersServers();
            LotteryManager lm = new LotteryManager();
            Orders o = os.GetOrder(OrderNo);
            if (o.PayTypeId == 7)
            {
                if (gus.UpdateUserMoney(o.AdminUserName, o.PayMoney * 10, "-"))
                {
                    if (os.UpdateOrder(OrderNo))
                    {

                    }
                    else
                    {
                        return "更新订单状态失败！";
                    }
                }
                else
                {
                    return "扣除平台币失败！";
                }
            }
            if (o.PayTypeId != 6)
            {
                lm.AddUserPoints(o.UserName, o.PayMoney);
            }
            if (o.Type == 1)
            {
                Games g = new Games();
                g = gss.GetGame(o.GameId);
                switch (g.GameNo)
                {
                    case "dxz":
                        return new Game_Dxz().Pay(OrderNo);
                    case "sjsg":
                        return new Game_Sjsg().Pay(OrderNo);
                    case "tj":
                        return new Game_Tj().Pay(OrderNo);
                    case "nz":
                        return new Game_Nz().Pay(OrderNo);
                    case "djj":
                        return new Game_Djj().Pay(OrderNo);
                    case "jlc":
                        return new Game_Jlc().Pay(OrderNo);
                    case "ly":
                        return new Game_Ly().Pay(OrderNo);
                    case "xyb":
                        return new Game_Xyb().Pay(OrderNo);
                    case "dhz":
                        return new Game_Dhz().Pay(OrderNo);
                    case "wz":
                        return new Game_Wz().Pay(OrderNo);
                    case "dpqk":
                        return new Game_Dpqk().Pay(OrderNo);
                    case "lm":
                        return new Game_Lm().Pay(OrderNo);
                    case "mxqy":
                        return new Game_Mxqy().Pay(OrderNo);
                    case "zsg":
                        return new Game_Zsg().Pay(OrderNo);
                    case "rxhzw":
                        return new Game_Rxhzw().Pay(OrderNo);
                    case "klsg":
                        return new Game_Klsg().Pay(OrderNo);
                    case "gjqx":
                        return new Game_Gjqx().Pay(OrderNo);
                    case "txj":
                        return new Game_Txj().Pay(OrderNo);
                    case "wdqk":
                        return new Game_Wdqk().Pay(OrderNo);
                    case "chcq":
                        return new Game_Chcq().Pay(OrderNo);
                    case "jjsg":
                        return new Game_Jjsg().Pay(OrderNo);
                    case "qh":
                        return new Game_Qh().Pay(OrderNo);
                    case "yjxy":
                        return new Game_Yjxy().Pay(OrderNo);
                    case "xxas":
                        return new Game_Xxas().Pay(OrderNo);
                    case "tgzt":
                        return new Game_Tgzt().Pay(OrderNo);
                    case "nslm":
                        return new Game_Nslm().Pay(OrderNo);
                    case "ftz":
                        return new Game_Ftz().Pay(OrderNo);
                    case "sbcs":
                        return new Game_Sbcs().Pay(OrderNo);
                    case "zwj":
                        return new Game_Zwj().Pay(OrderNo);
                    case "dqqyz":
                        return new Game_Dqqyz().Pay(OrderNo);
                    case "yxy":
                        return new Game_Yxy().Pay(OrderNo);
                    case "jhwj":
                        return new Game_Jhwj().Pay(OrderNo);
                    default:
                        return "不存在的游戏！";
                }
            }
            else
            {
                if (gus.UpdateUserMoney(o.UserName, o.PayMoney * 10, "+"))
                {
                    if (os.UpdateOrder(o.OrderNo))
                    {
                        return "充值成功！";
                    }
                    else
                    {
                        return "充值失败！错误原因：更新订单状态失败！";
                    }
                }
                else
                {
                    return "充值失败！";
                }
            }
        }

        /// <summary>
        /// 根据游戏编号获取游戏
        /// </summary>
        /// <param name="GameNo">游戏编号</param>
        /// <returns>返回游戏</returns>
        public Games GetGame(string GameNo)
        {
            return gss.GetGame(GameNo);
        }

        /// <summary>
        /// 根据游戏区服查询用户角色信息
        /// </summary>
        /// <param name="GameId">游戏Id</param>
        /// <param name="UserId">用户Id</param>
        /// <param name="ServerId">服务器Id</param>
        /// <returns>返回用户信息</returns>
        public GameUserInfo GetGameUserInfo(int GameId, int UserId, int ServerId)
        {
            GameUserInfo gui = new GameUserInfo();
            Games g = new Games();
            g = gss.GetGame(GameId);
            switch (g.GameNo)
            {
                case "dxz":
                    return new Game_Dxz().Sel(UserId, ServerId);
                case "sjsg":
                    return new Game_Sjsg().Sel(UserId, ServerId);
                case "tj":
                    return new Game_Qh().Sel(UserId, ServerId);
                case "nz":
                    return new Game_Nz().Sel(UserId, ServerId);
                case "djj":
                    return new Game_Djj().Sel(UserId, ServerId);
                case "jlc":
                    return new Game_Jlc().Sel(UserId, ServerId);
                case "ly":
                    return new Game_Ly().Sel(UserId, ServerId);
                case "xyb":
                    return new Game_Xyb().Sel(UserId, ServerId);
                case "dhz":
                    return new Game_Dhz().Sel(UserId, ServerId);
                case "wz":
                    return new Game_Wz().Sel(UserId, ServerId);
                case "dpqk":
                    return new Game_Dpqk().Sel(UserId, ServerId);
                case "lm":
                    return new Game_Lm().Sel(UserId, ServerId);
                case "mxqy":
                    return new Game_Mxqy().Sel(UserId, ServerId);
                case "zsg":
                    return new Game_Zsg().Sel(UserId, ServerId);
                case "rxhzw":
                    return new Game_Rxhzw().Sel(UserId, ServerId);
                case "klsg":
                    return new Game_Klsg().Sel(UserId, ServerId);
                case "gjqx":
                    return new Game_Gjqx().Sel(UserId, ServerId);
                case "txj":
                    return new Game_Txj().Sel(UserId, ServerId);
                case "wdqk":
                    return new Game_Wdqk().Sel(UserId, ServerId);
                case "chcq":
                    return new Game_Chcq().Sel(UserId, ServerId);
                case "jjsg":
                    return new Game_Jjsg().Sel(UserId, ServerId);
                case "qh":
                    return new Game_Qh().Sel(UserId, ServerId);
                case "yjxy":
                    return new Game_Yjxy().Sel(UserId, ServerId);
                case "xxas":
                    return new Game_Xxas().Sel(UserId, ServerId);
                case "tgzt":
                    return new Game_Tgzt().Sel(UserId, ServerId);
                case "nslm":
                    return new Game_Nslm().Sel(UserId, ServerId);
                case "ftz":
                    return new Game_Ftz().Sel(UserId, ServerId);
                case "sbcs":
                    return new Game_Sbcs().Sel(UserId, ServerId);
                case "zwj":
                    return new Game_Zwj().Sel(UserId, ServerId);
                case "dqqyz":
                    return new Game_Dqqyz().Sel(UserId, ServerId);
                case "yxy":
                    return new Game_Yxy().Sel(UserId, ServerId);
                case "jhwj":
                    return new Game_Jhwj().Sel(UserId, ServerId);
                default:
                    return gui;
            }
        }

        /// <summary>
        /// 获取游戏的登录地址
        /// </summary>
        /// <param name="GameId">游戏Id</param>
        /// <param name="UserId">用户Id</param>
        /// <param name="ServerId">服务器Id</param>
        /// <returns>返回登陆地址</returns>
        public string LoginUrl(int GameId, int UserId, int ServerId)
        {
            GameUserInfo gui = new GameUserInfo();
            Games g = new Games();
            g = gss.GetGame(GameId);
            switch (g.GameNo)
            {
                case "dxz":
                    return new Game_Dxz().Login(UserId, ServerId, 0);
                case "sjsg":
                    return new Game_Sjsg().Login(UserId, ServerId, 0);
                case "tj":
                    return new Game_Tj().Login(UserId, ServerId, 0);
                case "nz":
                    return new Game_Nz().Login(UserId, ServerId, 0);
                case "djj":
                    return new Game_Djj().Login(UserId, ServerId, 0);
                case "jlc":
                    return new Game_Jlc().Login(UserId, ServerId, 0);
                case "ly":
                    return new Game_Ly().Login(UserId, ServerId, 0);
                case "xyb":
                    return new Game_Xyb().Login(UserId, ServerId, 0);
                case "dhz":
                    return new Game_Dhz().Login(UserId, ServerId, 0);
                case "wz":
                    return new Game_Wz().Login(UserId, ServerId, 0);
                case "dpqk":
                    return new Game_Dpqk().Login(UserId, ServerId, 0);
                case "lm":
                    return new Game_Lm().Login(UserId, ServerId, 0);
                case "mxqy":
                    return new Game_Mxqy().Login(UserId, ServerId, 0);
                case "zsg":
                    return new Game_Zsg().Login(UserId, ServerId, 0);
                case "rxhzw":
                    return new Game_Rxhzw().Login(UserId, ServerId, 0);
                case "klsg":
                    return new Game_Klsg().Login(UserId, ServerId, 0);
                case "gjqx":
                    return new Game_Gjqx().Login(UserId, ServerId, 0);
                case "txj":
                    return new Game_Txj().Login(UserId, ServerId, 0);
                case "wdqk":
                    return new Game_Wdqk().Login(UserId, ServerId, 0);
                case "chcq":
                    return new Game_Chcq().Login(UserId, ServerId, 0);
                case "jjsg":
                    return new Game_Jjsg().Login(UserId, ServerId, 0);
                case "qh":
                    return new Game_Qh().Login(UserId, ServerId, 0);
                case "yjxy":
                    return new Game_Yjxy().Login(UserId, ServerId, 0);
                case "xxas":
                    return new Game_Xxas().Login(UserId, ServerId, 0);
                case "tgzt":
                    return new Game_Tgzt().Login(UserId, ServerId, 0);
                case "nslm":
                    return new Game_Nslm().Login(UserId, ServerId, 0);
                case "ftz":
                    return new Game_Ftz().Login(UserId, ServerId, 0);
                case "sbcs":
                    return new Game_Sbcs().Login(UserId, ServerId, 0);
                case "zwj":
                    return new Game_Zwj().Login(UserId, ServerId, 0);
                case "dqqyz":
                    return new Game_Dqqyz().Login(UserId, ServerId, 0);
                case "yxy":
                    return new Game_Yxy().Login(UserId, ServerId, 0);
                case "jhwj":
                    return new Game_Jhwj().Login(UserId, ServerId, 0);
                default:
                    return "";
            }
        }

        /// <summary>
        /// 获取游戏总条数
        /// </summary>
        /// <param name="WhereStr">条件</param>
        /// <returns>游戏数</returns>
        public Double GetGamesCount(string WhereStr)
        {
            return gss.GetGamesCount(WhereStr);
        }

        /// <summary>
        /// 获取游戏分页数据
        /// </summary>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageNum">页码</param>
        /// <param name="WhereStr">条件</param>
        /// <param name="OrderBy">排序</param>
        /// <returns>返回游戏数据集合</returns>
        public List<Games> GetAll(int PageSize, int PageNum, string WhereStr, string OrderBy)
        {
            return gss.GetAll(PageSize, PageNum, WhereStr, OrderBy);
        }

        /// <summary>
        /// 更新游戏信息
        /// </summary>
        /// <param name="g">游戏</param>
        /// <returns>返回是否更新成功</returns>
        public Boolean UpdateGame(Games g)
        {
            return gss.UpdateGame(g);
        }

        /// <summary>
        /// 添加游戏信息
        /// </summary>
        /// <param name="g">游戏</param>
        /// <returns>返回是否添加成功</returns>
        public Boolean AddGame(Games g)
        {
            return gss.AddGame(g);
        }

        /// <summary>
        /// 删除游戏
        /// </summary>
        /// <param name="GameId">游戏Id</param>
        /// <returns>返回是否删除成功</returns>
        public Boolean DelGame(int GameId)
        {
            return gss.DelGame(GameId);
        }

        /// <summary>
        /// 获取游戏
        /// </summary>
        /// <param name="Top">前几条</param>
        /// <param name="Type">类型</param>
        /// <returns>返回游戏集合</returns>
        public List<Games> GetAll(int Top, string Type)
        {
            return gss.GetAll(Top, Type);
        }
    }
}
