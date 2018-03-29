using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace slnLinq.Controllers
{
    public class DefaultController : Controller
    {
        // 整數陣列遞減排序
        public string ShowArrayDesc()
        {
            int[] score = new int[] { 78, 99, 20, 100, 66 };
            string show = "";

            var result = score.OrderByDescending(m=>m);
            show = "遞減排序";
            foreach (var r in result)
                show += r + ",";

            show += "<br />";
            show += "總合：" + result.Sum();

            return show;
        }

        // 整數陣列遞增排序
        public string ShowArrayAsc()
        {
            int[] score = new int[] { 78, 99, 20, 100, 66 };
            string show = "";

            var result = score.OrderBy(m => m);

            show = "遞增排序：";
            foreach (var r in result)
                show += r + ",";

            show += "<br />";
            show += "平均：" + result.Average();

            return show;
        }

        public string LogingMember(string uid, string pwd)
        {
            Member[] members = new Member[]
            {
                new Member{UId="Tom", Pwd="123", Name="Tom"},
                new Member{UId="Jasper",Pwd="456",Name="Jasper"},
                new Member{UId="Mary",Pwd="789",Name="Mary"}
            };

            var result = members.Where(m => m.UId == uid && m.Pwd == pwd).FirstOrDefault();

            string show = "";

            if (result != null)
                show = result.Name + "歡迎進入系統";
            else
                show = "帳號密碥錯誤！";

            return show;
        }
    }
}