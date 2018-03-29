using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using slnLinq.Models;

namespace slnLinq.Controllers
{
    public class LinqController : Controller
    {
        // 資料庫物件
        NorthwindEntities db = new NorthwindEntities();

        // 顯示所有員工資料
        public string ShowEmployee()
        {
            // 取得所有員工記錄
            var result = db.員工;

            string show = "";
            // 逐一取得詳細員工記錄
            foreach(var item in result)
            {
                show += "編號：" + item.員工編號 + "<br />";
                show += "姓名：" + item.姓名 + item.稱呼 + "<br />";
                show += "職稱：" + item.職稱 + "<hr>";
            }

            return show;
        }

        // 找出客戶中含有 keyword 關鍵字的客戶記錄
        public string ShowCustomerByAddress(string keyword)
        {
            var result = db.客戶.Where(m => m.地址.Contains(keyword));

            string show = "";
            foreach(var item in result)
            {
                show += "公司：" + item.公司名稱 + "<br />";
                show += "姓名：" + item.連絡人 + item.連絡人職稱 + "<br />";
                show += "地址：" + item.地址 + "<hr>";
            }

            return show;
        }

        // 查詢單價大於 30 的產品，並依單價做遞增排序，庫存做遞減排序
        public string ShowProduct()
        {
            var result = db.產品資料
                .Where(m => m.單價 > 30)
                .OrderBy(m => m.單價)
                .ThenByDescending(m => m.庫存量);

            string show = "";
            foreach(var item in result)
            {
                show += "產品：" + item.產品 + "<br />";
                show += "單價：" + item.單價 + "<br />";
                show += "庫存：" + item.庫存量 + "<hr>";
            }

            return show;
        }

        // 查詢產品平均單價、總合、筆數，最高價和最低價資訊
        public string ShowProductInfo()
        {
            // 取得所有產品資訊
            var result = db.產品資料;

            string show = "";

            show += "單價平均：" + result.Average(m => m.單價) + "<br />";
            show += "總合：" + result.Sum(m => m.單價) + "<br />";
            show += "筆數：" + result.Count() + "<br />";
            show += "最高單價：" + result.Max(m => m.單價) + "<br />";
            show += "最低單價：" + result.Min(m => m.單價) + "<hr>";

            return show;
        }
    }
}