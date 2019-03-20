using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWeb.Models;
using service;
using service.Dto;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index( )
        {
            //var param = new UserInfoPagedDto();
            //var userData = new UserInfoDataBase();
            //var resultData = userData.pageList(param);
            //var rows = resultData.Values.FirstOrDefault();
            //var total = resultData.Keys.FirstOrDefault();
            //ViewData["Datatotal"] = total;
            return View();
        }
        public IActionResult Detail(string UserInfoId)
        {  
            var userData = new UserInfoDataBase();
            var datas = userData.GetUserInfo(UserInfoId);
            var imglist= userData.GetImg(UserInfoId);
            ViewData["imglist"] = imglist;
            //@ViewData
            return View(datas);
        }
      
    }
}
