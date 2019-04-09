using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using NewLife.Cube;
using NewLife.School.Entity;
using NewLife.Web;
using XCode.Membership;

namespace CubeDemo.Areas.School.Controllers
{

    public class LinkController : EntityController<CustomerLink>
    {
        static LinkController()
        {
            ListFields.RemoveField("Remark");
        }

         
        [AllowAnonymous]
        public ActionResult Info()
        {
           
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Submit(String username, String mobile,int accessType=2)
        {
            try
            {
                if (String.IsNullOrEmpty(username)) throw new ArgumentNullException("username", "用户名不能为空！");
                if (String.IsNullOrEmpty(mobile)) throw new ArgumentNullException("mobile", "手机号码不能为空！");

                var customerLink = new CustomerLink()
                {
                    Name = username,
                    Mobile = mobile,
                    AccessType=accessType
                };

                customerLink.Insert();
            }
            catch (ArgumentException aex)
            {
                ModelState.AddModelError(aex.ParamName, aex.Message);
                return View("Info", ModelState);
            }

            return View("Welcome");
        }


        [AllowAnonymous]
        public ActionResult Welcome()
        {
            return View();
        }

        /// <summary>批量启用</summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        [EntityAuthorize(PermissionFlags.Update)]
        public ActionResult EnableSelect(String keys)
        {
            return EnableOrDisableSelect();
        }

        private ActionResult EnableOrDisableSelect(Boolean isEnable = true)
        {
            var count = 0;
            var ids = GetRequest("keys").SplitAsInt();
            if (ids.Length > 0)
            {
                Parallel.ForEach(ids, id =>
                {
                    var user = CustomerLink.FindByID(id);
                    if (user != null && user.IsLink != isEnable)
                    {
                        user.IsLink = isEnable;
                        user.Save();

                        Interlocked.Increment(ref count);
                    }
                });
            }

            return JsonRefresh("共{1}[{0}]个意向客户".F(count, isEnable ? "联系" : "重新联系"));
        }


        [AllowAnonymous]
        public ActionResult QrCode()
        {
            //生成二维码 
            QRCode.RQCodeClass rqClass = new QRCode.RQCodeClass();
            string url = HttpRuntime.BinDirectory + "LinkInfo.jpg";
            Bitmap bitmap = rqClass.GetCreateQRCodeImg("http://localhost:2034/School/Link/Info", 700, 3);
            bitmap.Save(url);
            //string strPath = HttpContext.Server.MapPath("main_2.jpg");
            //Bitmap insertImg = rqClass.GetCreateQRCodeInsertSmallImg("http://www.baidu.com", strPath, 700, 3);
            //insertImg.Save(HttpRuntime.BinDirectory + "LinkInfo.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            bitmap.Dispose();
            //insertImg.Dispose(); 
            return Json(url,JsonRequestBehavior.AllowGet);
        }
    }
}