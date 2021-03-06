﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyWeb.help;
using service;
using System.Data;
using service.Model;
using service.Dto;
using Microsoft.AspNetCore.Http;

namespace MyWeb.Controllers
{

    public class PictureController : Controller
    {
        private IHostingEnvironment hostingEnv;
        string[] pictureFormatArray = { "png", "jpg", "jpeg", "bmp", "gif", "ico", "PNG", "JPG", "JPEG", "BMP", "GIF", "ICO" };

        public PictureController(IHostingEnvironment env)
        {
            hostingEnv = env;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult CreateTable()
        {
            var t = new test();
            t.createNewDatabase();
            return Content("123");
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserInfo data)
        {
          
            string result = "上传对象为空!!!";
            if (data != null)
            {
                var userData = new UserInfoDataBase();

                string strsql = string.Format($@"insert into  UserInfo values('{data.Id}','{data.UserName}','{data.Phone}','{data.Address}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff")}'
                                      ,'{data.MakeRoomTime}','{data.SellingPoint}','{data.RoomNumber}','{data.Price}','{data.AllPrice}','{data.Areas}','{data.Apartment}'
                                      ,'{data.Remark}')");
                var dataCount = SQLiteHelper.ExecuteNonQuery(strsql);
                if (dataCount > 0)
                {
                    result = "操作成功!!!";
                }
                else
                {
                    result = "数据保存失败!!!";
                }
            }


            //var data =new UserInfo()
            //{
            //    Id = Guid.NewGuid(),
            //    Address = "成都",
            //    AllPrice = "50",
            //    Apartment = "一室一厅",
            //    Areas = "50",
            //    CreateTime = DateTime.Now,
            //    MakeRoomTime = "2012年5月20号",
            //    Phone = "12312323",
            //    Price = "1",
            //   Remark = "hao",
            //   UserName = "123",
            //   SellingPoint = "123",
            //   RoomNumber = "123",
            //};


            return Json(result);
        }
        [HttpGet]
        public IActionResult PageList([FromQuery]UserInfoPagedDto param)
        {

            var userData = new UserInfoDataBase();
            var resultData = userData.pageList(param);
            var rows = resultData.Values.FirstOrDefault();
            var total = resultData.Keys.FirstOrDefault();
            return Json(new { total = total, rows = rows, index = param.offset });
        }

        [HttpGet]
        public IActionResult GetUrl(string url)
        {
            string result = "不存在";
            string filePathd = hostingEnv.WebRootPath;
          
            if  (!string.IsNullOrWhiteSpace(url))
            {
                if (System.IO.Directory.Exists(filePathd + "\\Files\\Picture\\"+ url))
                {
                    result = "存在";
                }
            }
            else
            {
                if (System.IO.Directory.Exists(filePathd + "\\Files\\Picture\\"))
                {
                    result = "存在";
                }
            }

            return Content(result);
        }



        [HttpPost]
        public IActionResult Remove([FromBody]RemoveParam param)
        {
            string result = "";
            if (param.Id == Guid.Empty)
            {
                result = "对象不能为空!!!";
            }
            else
            {
                string strsql = $"delete FROM UserInfo where Id= '{param.Id}'";
                var dataCount = SQLiteHelper.ExecuteNonQuery(strsql);
                if (dataCount > 0)
                {
                    result = "操作成功!!!";
                }
            }
            return Json(result);

        }


        [HttpPost]
        public IActionResult UpImg([FromForm]IFormCollection formData)
        {
            
            try
            {
                IFormFileCollection files = formData.Files;
                var ImgId = Request.Form["ImgId"];
                var Imgtype = Request.Form["Imgtype"];
                var userData = new UserInfoDataBase();
                long size = files.Sum(f => f.Length);

                //size > 100MB refuse upload !
                if (size > 104857600)
                {
                    return Json(Return_Helper_DG.Error_Msg_Ecode_Elevel_HttpCode("图片总共大小不能超过 100MB "));
                }
             
                List<string> filePathResultList = new List<string>();
                string filePathd = hostingEnv.WebRootPath;
                //+ $@"\Files\Pictures\";
                if (!System.IO.Directory.Exists(filePathd + "/Files"))
                {
                    System.IO.Directory.CreateDirectory(filePathd + "/Files");
                }
                if (!System.IO.Directory.Exists(filePathd + "/Files/Picture/"))
                {
                    System.IO.Directory.CreateDirectory(filePathd + "/Files//Pictures/");
                }

                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    string filePath = hostingEnv.WebRootPath + "/Files/Pictures/";

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    string suffix = fileName.Split('.')[1];

                    if (!pictureFormatArray.Contains(suffix))
                    {
                        return Json(Return_Helper_DG.Error_Msg_Ecode_Elevel_HttpCode("当前图片格式不支持"));
                    }

                    fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff").Replace('0','1') + "." + suffix;

                    string fileFullName = filePath + fileName;
              
                    var entit = new Img();
                    entit.Id = Guid.NewGuid();
                    entit.UserInfoId = Guid.Parse(ImgId);
                    entit.CreateTime = DateTime.Now;
                    entit.Type = Convert.ToInt16(Imgtype);
                    entit.Url = "/Files/Pictures/" +fileName;
                    //保存数据
                    userData.AddImg(entit);
                    using (FileStream fs = System.IO.File.Create(fileFullName))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                    filePathResultList.Add(fileFullName);
                }

                string message = $"上传成功";

           return   Json(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode(message, filePathResultList, filePathResultList.Count))  ;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
